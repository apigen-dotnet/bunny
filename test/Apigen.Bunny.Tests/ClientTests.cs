using System.Net;
using System.Reflection;
using System.Text;
using System.Text.Json;
using Apigen.Bunny.Core;
using Apigen.Bunny.Core.Models;
using Apigen.Bunny.EdgeScripting;
using Apigen.Bunny.Logging;
using Apigen.Bunny.MagicContainers;
using Apigen.Bunny.OriginErrors;
using Apigen.Bunny.Shield;
using Apigen.Bunny.Storage;
using Apigen.Bunny.Stream;

namespace Apigen.Bunny.Tests;

public class ClientTests
{
  [Fact]
  public void Factories_SetIndependentCredentialsAndCorrectEndpoints()
  {
    using var core = BunnyCoreClient.WithAccessKey("account-key");
    using var origin = BunnyOriginErrorsClient.WithAccessKeyAuth("origin-key");
    using var logging = BunnyLoggingClient.WithApiKey("logging-key");
    using var storage = BunnyStorageClient.WithApiKey("zone-password", "https://sg.storage.bunnycdn.com");
    using var stream = BunnyStreamClient.WithApiKey("library-key");
    using var shield = BunnyShieldClient.WithApiKey("shield-key");
    using var scripting = BunnyEdgeScriptingClient.WithAccessKey("scripting-key");
    using var containers = BunnyMagicContainersClient.WithApiKey("containers-key");

    AssertClient(core, "https://api.bunny.net/", "account-key");
    AssertClient(origin, "https://cdn-origin-logging.bunny.net/", "origin-key");
    AssertClient(logging, "https://logging.bunnycdn.com/", "logging-key");
    AssertClient(storage, "https://sg.storage.bunnycdn.com/", "zone-password");
    AssertClient(stream, "https://video.bunnycdn.com/", "library-key");
    AssertClient(shield, "https://api.bunny.net/", "shield-key");
    AssertClient(scripting, "https://api.bunny.net/", "scripting-key");
    AssertClient(containers, "https://api.bunny.net/mc/", "containers-key");
  }

  [Theory]
  [InlineData("", "/zone/file%20%23.bin")]
  [InlineData("images/nested folder", "/zone/images/nested%20folder/file%20%23.bin")]
  [InlineData("/images/", "/zone/images/file%20%23.bin")]
  public async Task Storage_UploadsUnmodifiedBytesAndEscapesPathSegments(string path, string expectedPath)
  {
    byte[] bytes = [0, 255, 13, 10, 128, 34];
    using var http = CreateHttp("https://storage.bunnycdn.com/", async request =>
    {
      Assert.Equal(HttpMethod.Put, request.Method);
      Assert.Equal(expectedPath, request.RequestUri!.AbsolutePath);
      Assert.Equal("application/octet-stream", request.Content!.Headers.ContentType!.MediaType);
      Assert.Equal(bytes, await request.Content.ReadAsByteArrayAsync());
      return new(HttpStatusCode.Created);
    });
    using var client = new BunnyStorageClient(http);
    using var input = new MemoryStream(bytes);

    await client.ManageFiles.PutAsync("zone", path, "file #.bin", input);

    Assert.True(input.CanRead);
  }

  [Fact]
  public async Task Storage_ListsRootDirectory()
  {
    using var http = CreateHttp("https://storage.bunnycdn.com/", request =>
    {
      Assert.Equal("/zone/", request.RequestUri!.AbsolutePath);
      return Task.FromResult(Json("""[{"ObjectName":"file.bin","Length":6,"IsDirectory":false}]"""));
    });
    using var client = new BunnyStorageClient(http);
    var files = await client.BrowseFiles.GetAsync("zone", "");
    Assert.Equal("file.bin", Assert.Single(files).ObjectName);
  }

  [Fact]
  public async Task Storage_DownloadDoesNotBufferTheEntireResponse()
  {
    byte[] bytes = [0, 1, 255, 128];
    using var content = new UnbufferedContent(bytes);
    using var http = CreateHttp("https://storage.bunnycdn.com/", _ =>
      Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = content }));
    using var client = new BunnyStorageClient(http);
    using var download = await client.ManageFiles.GetAsync("zone", "images", "file.bin");
    using var output = new MemoryStream();
    await download.CopyToAsync(output);
    Assert.Equal(bytes, output.ToArray());
  }

  [Fact]
  public async Task Stream_UploadsVideoBytes()
  {
    byte[] bytes = [0, 255, 13, 10];
    using var http = CreateHttp("https://video.bunnycdn.com/", async request =>
    {
      Assert.Equal(HttpMethod.Put, request.Method);
      Assert.Equal("/library/42/videos/video-id", request.RequestUri!.AbsolutePath);
      Assert.Equal("application/octet-stream", request.Content!.Headers.ContentType!.MediaType);
      Assert.Equal(bytes, await request.Content.ReadAsByteArrayAsync());
      return Json("""{"success":true,"statusCode":200}""");
    });
    using var client = new BunnyStreamClient(http);
    using var input = new MemoryStream(bytes);
    var result = await client.ManageVideos.VideoUploadVideoAsync(42, "video-id", input);
    Assert.True(result.Success);
  }

  [Fact]
  public async Task Stream_ThumbnailUrlDoesNotRequireAnUpload()
  {
    using var http = CreateHttp("https://video.bunnycdn.com/", request =>
    {
      Assert.Null(request.Content);
      Assert.Contains("thumbnailUrl=", request.RequestUri!.Query);
      return Task.FromResult(Json("""{"success":true}"""));
    });
    using var client = new BunnyStreamClient(http);
    var result = await client.ManageVideos.VideoSetThumbnailAsync(42, "video-id",
      request: new() { ThumbnailUrl = "https://example.com/image.jpg" });
    Assert.True(result.Success);
  }

  [Fact]
  public async Task Logging_DeserializesEntriesAndPaginationFromOneEnvelope()
  {
    using var http = CreateHttp("https://logging.bunnycdn.com/", request =>
    {
      Assert.Equal("/v2/pullzones/42/logs", request.RequestUri!.AbsolutePath);
      return Task.FromResult(Json("""
        {"data":[{"requestId":"abc","statusCode":200,"timestamp":"2026-09-08T12:00:00Z"}],
         "pagination":{"offset":0,"limit":100,"returned":1,"hasMore":false},
         "query":{"pullZoneId":42,"from":"2026-09-08T00:00:00Z","to":"2026-09-09T00:00:00Z","order":"desc"}}
        """));
    });
    using var client = new BunnyLoggingClient(http);
    var result = await client.LoggingV2.GetAsync(42);
    Assert.Equal("abc", Assert.Single(result.Data!).RequestId);
    Assert.Equal(1, result.Pagination.Returned);
    Assert.Equal(42, result.Query.PullZoneId);
  }

  [Fact]
  public async Task Logging_ReturnsLegacyLogBytes()
  {
    using var http = CreateHttp("https://logging.bunnycdn.com/", _ =>
      Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("HIT|200|/file\n") }));
    using var client = new BunnyLoggingClient(http);
    using var download = await client.LoggingV1.GetAsync("09-08-2026", 42);
    using var reader = new StreamReader(download);
    Assert.Equal("HIT|200|/file\n", await reader.ReadToEndAsync());
  }

  [Fact]
  public async Task OriginErrors_HasCallableOperationAndTypedLogs()
  {
    using var http = CreateHttp("https://cdn-origin-logging.bunny.net/", request =>
    {
      Assert.Equal("/42/2026-09-08", request.RequestUri!.AbsolutePath);
      return Task.FromResult(Json("""{"logs":[{"log":"Connection refused","timestamp":123}]}"""));
    });
    using var client = new BunnyOriginErrorsClient(http);
    var result = await client.OriginErrors.GetAsync(42, "2026-09-08");
    Assert.Equal("Connection refused", Assert.Single(result.Logs!).Log);
  }

  [Fact]
  public async Task Shield_DeserializesTheDeclaredResponseEnvelope()
  {
    using var http = CreateHttp("https://api.bunny.net/", _ =>
      Task.FromResult(Json("""{"data":{"shieldZoneId":12,"pullZoneId":42,"wafEnabled":true}}""")));
    using var client = new BunnyShieldClient(http);
    var result = await client.ShieldZone.GetShieldZoneConfigurationAsync(12);
    Assert.Equal(12, result.Data!.ShieldZoneId);
    Assert.True(result.Data.WafEnabled);
  }

  [Fact]
  public async Task MagicContainers_PreservesMcPrefixAndSendsEnvironmentDictionary()
  {
    using var http = CreateHttp("https://api.bunny.net/mc/", async request =>
    {
      Assert.Equal("/mc/apps/app/containers/container/env", request.RequestUri!.AbsolutePath);
      Assert.Equal(HttpMethod.Put, request.Method);
      using var body = JsonDocument.Parse(await request.Content!.ReadAsStringAsync());
      Assert.Equal("value", body.RootElement.GetProperty("VARIABLE").GetString());
      return Json("""{"id":"container","environmentVariables":[{"name":"VARIABLE","value":"value"}]}""");
    });
    using var client = new BunnyMagicContainersClient(http);
    var result = await client.Containers.SetContainerEnvironmentVariablesAsync("app", "container", new() { ["VARIABLE"] = "value" });
    Assert.Equal("container", result.Id);
  }

  [Fact]
  public async Task Core_SendsBodyReferencedThroughOneOf()
  {
    using var http = CreateHttp("https://api.bunny.net/", async request =>
    {
      Assert.Equal("/pullzone/42/purgeCache", request.RequestUri!.AbsolutePath);
      using var body = JsonDocument.Parse(await request.Content!.ReadAsStringAsync());
      Assert.Equal("images", body.RootElement.GetProperty("CacheTag").GetString());
      return new(HttpStatusCode.NoContent);
    });
    using var client = new BunnyCoreClient(http);
    await client.PullZone.PublicPurgeCachePostByTagAsync(42, new PullZonePurgeModel { CacheTag = "images" });
  }

  [Fact]
  public async Task EdgeScripting_PreservesComputePrefix()
  {
    using var http = CreateHttp("https://api.bunny.net/", request =>
    {
      Assert.Equal("/compute/script/42", request.RequestUri!.AbsolutePath);
      return Task.FromResult(Json("""{"Id":42,"Name":"example"}"""));
    });
    using var client = new BunnyEdgeScriptingClient(http);
    var result = await client.EdgeScript.GetEdgeScriptByIdEndpointGetEdgeScriptByIdAsync(42);
    Assert.Equal(42, result.Id);
  }

  [Fact]
  public async Task Storage_ErrorsExposeStatusAndResponseBody()
  {
    using var http = CreateHttp("https://storage.bunnycdn.com/", _ =>
      Task.FromResult(new HttpResponseMessage(HttpStatusCode.Unauthorized) { Content = new StringContent("Invalid AccessKey") }));
    using var client = new BunnyStorageClient(http);
    var error = await Assert.ThrowsAsync<Apigen.Bunny.Storage.ApiException>(() =>
      client.ManageFiles.GetAsync("zone", "", "file"));
    Assert.Equal(HttpStatusCode.Unauthorized, error.StatusCode);
    Assert.Equal("Invalid AccessKey", error.ResponseBody);
  }

  private static void AssertClient(object client, string baseUrl, string key)
  {
    var field = client.GetType().GetField("_httpClient", BindingFlags.Instance | BindingFlags.NonPublic)!;
    var http = (HttpClient)field.GetValue(client)!;
    Assert.Equal(baseUrl, http.BaseAddress!.AbsoluteUri);
    Assert.Equal(key, Assert.Single(http.DefaultRequestHeaders.GetValues("AccessKey")));
    Assert.False(http.DefaultRequestHeaders.Contains("Authorization"));
  }

  private static HttpClient CreateHttp(string baseUrl, Func<HttpRequestMessage, Task<HttpResponseMessage>> respond) =>
    new(new Handler(respond)) { BaseAddress = new Uri(baseUrl) };

  private static HttpResponseMessage Json(string json) =>
    new(HttpStatusCode.OK) { Content = new StringContent(json, Encoding.UTF8, "application/json") };

  private sealed class Handler(Func<HttpRequestMessage, Task<HttpResponseMessage>> respond) : HttpMessageHandler
  {
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) => respond(request);
  }

  private sealed class UnbufferedContent(byte[] bytes) : HttpContent
  {
    protected override Task SerializeToStreamAsync(System.IO.Stream stream, TransportContext? context) =>
      throw new InvalidOperationException("The response must not be buffered before returning the download stream.");

    protected override Task<System.IO.Stream> CreateContentReadStreamAsync() =>
      Task.FromResult<System.IO.Stream>(new MemoryStream(bytes));

    protected override bool TryComputeLength(out long length)
    {
      length = 0;
      return false;
    }
  }
}
