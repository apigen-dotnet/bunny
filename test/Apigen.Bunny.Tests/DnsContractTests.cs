using System.Net;
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

public class DnsContractTests
{
  [Theory]
  [InlineData(typeof(BunnyCoreClient))]
  [InlineData(typeof(BunnyEdgeScriptingClient))]
  [InlineData(typeof(BunnyLoggingClient))]
  [InlineData(typeof(BunnyMagicContainersClient))]
  [InlineData(typeof(BunnyOriginErrorsClient))]
  [InlineData(typeof(BunnyShieldClient))]
  [InlineData(typeof(BunnyStorageClient))]
  [InlineData(typeof(BunnyStreamClient))]
  public void ResourceClientsImplementTheirInterfaces(Type factory)
  {
    Type[] interfaces = factory.Assembly.GetExportedTypes()
      .Where(type => type.IsInterface && type.Name.EndsWith("Client", StringComparison.Ordinal)).ToArray();
    Assert.NotEmpty(interfaces);
    foreach (Type contract in interfaces)
    {
      Type implementation = factory.Assembly.GetType($"{contract.Namespace}.{contract.Name[1..]}", throwOnError: true)!;
      Assert.True(contract.IsAssignableFrom(implementation), $"{implementation.FullName} must implement {contract.Name}.");
    }
  }

  [Fact]
  public void DnsRequestTypesAreNullableEnumsWithSchemaNames()
  {
    Assert.Equal(typeof(DnsRecordTypes?), typeof(AddDnsRecordModel).GetProperty("Type")!.PropertyType);
    Assert.Equal(typeof(DnsRecordTypes?), typeof(UpdateDnsRecordModel).GetProperty("Type")!.PropertyType);
    Assert.Equal("A", Enum.GetName((DnsRecordTypes)0));
    Assert.Equal("MX", Enum.GetName((DnsRecordTypes)4));
  }

  [Theory]
  [InlineData(false, 0)]
  [InlineData(false, 4)]
  [InlineData(false, null)]
  [InlineData(true, 0)]
  [InlineData(true, 4)]
  [InlineData(true, null)]
  public async Task DnsWritesNumericTypesAndOmitsNull(bool update, int? type)
  {
    int requests = 0;
    using HttpClient http = new(new Handler(async request =>
    {
      requests++;
      Assert.Equal(update ? HttpMethod.Post : HttpMethod.Put, request.Method);
      Assert.Equal(update ? "/dnszone/42/records/7" : "/dnszone/42/records", request.RequestUri!.AbsolutePath);
      using JsonDocument body = JsonDocument.Parse(await request.Content!.ReadAsStringAsync());
      if (type.HasValue)
      {
        JsonElement value = body.RootElement.GetProperty("Type");
        Assert.Equal(JsonValueKind.Number, value.ValueKind);
        Assert.Equal(type.Value, value.GetInt32());
      }
      else
      {
        Assert.False(body.RootElement.TryGetProperty("Type", out _));
      }
      return new HttpResponseMessage(update ? HttpStatusCode.NoContent : HttpStatusCode.Created)
      {
        Content = new StringContent($$"""{"Id":7,"Type":{{type ?? 0}},"Name":"www"}""")
      };
    })) { BaseAddress = new Uri("https://example.invalid/") };
    using BunnyCoreClient client = new(http);
    IDnsZoneClient dns = client.DnsZone;
    DnsRecordTypes? recordType = type.HasValue ? (DnsRecordTypes)type.Value : null;
    if (update)
    {
      await dns.PublicUpdateRecordAsync(42, 7, new() { Type = recordType, Name = "www" });
    }
    else
    {
      DnsRecordModel result = await dns.PublicAddRecordAsync(42, new() { Type = recordType, Name = "www" });
      Assert.Equal((DnsRecordTypes)(type ?? 0), result.Type);
    }
    Assert.Equal(1, requests);
  }

  [Fact]
  public void BoxedNumericEnumsAndStringEnumsKeepTheirWireTypes()
  {
    JsonSerializerOptions options = new();
    options.Converters.Add(new Apigen.Bunny.Core.SmartEnumConverterFactory());
    Assert.Equal("0", JsonSerializer.Serialize<object>((DnsRecordTypes)0, options));
    Assert.Equal("4", JsonSerializer.Serialize<object>((DnsRecordTypes)4, options));
    Assert.Equal("0", JsonSerializer.Serialize((DnsRecordTypes)0));
    Assert.Equal("\"Ascending\"", JsonSerializer.Serialize(LogOrdering.Ascending, options));
    Assert.Equal(LogOrdering.Descending, JsonSerializer.Deserialize<LogOrdering>("\"Descending\"", options));
  }

  private sealed class Handler(Func<HttpRequestMessage, Task<HttpResponseMessage>> respond) : HttpMessageHandler
  {
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) =>
      respond(request);
  }
}
