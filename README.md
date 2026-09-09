# Apigen.Bunny

One NuGet package with eight independent, generated .NET 10 clients for the
[bunny.net APIs](https://bunny.net/docs/openapi).

```bash
dotnet add package Apigen.Bunny
```

| Namespace / client | Base URL | Credential |
|---|---|---|
| `Apigen.Bunny.Core` / `BunnyCoreClient` | `https://api.bunny.net` | Account API key |
| `Apigen.Bunny.OriginErrors` / `BunnyOriginErrorsClient` | `https://cdn-origin-logging.bunny.net` | Account API key |
| `Apigen.Bunny.Logging` / `BunnyLoggingClient` | `https://logging.bunnycdn.com` | Account API key |
| `Apigen.Bunny.Storage` / `BunnyStorageClient` | `https://storage.bunnycdn.com` or your zone's regional endpoint | Storage zone password |
| `Apigen.Bunny.Stream` / `BunnyStreamClient` | `https://video.bunnycdn.com` | Video library API key |
| `Apigen.Bunny.Shield` / `BunnyShieldClient` | `https://api.bunny.net` | Account API key |
| `Apigen.Bunny.EdgeScripting` / `BunnyEdgeScriptingClient` | `https://api.bunny.net` | Account API key |
| `Apigen.Bunny.MagicContainers` / `BunnyMagicContainersClient` | `https://api.bunny.net/mc` | Account API key |

Includes all 275 operations in the eight source specifications, including both
CDN Logging versions. Each client has its own HTTP client and credentials, with
models in its `.Models` namespace. All client and model assemblies ship inside
the single package; logging abstractions and data annotations are external NuGet
dependencies.

## Usage

```csharp
using Apigen.Bunny.Core;
using Apigen.Bunny.Storage;
using Apigen.Bunny.Stream;

using var core = BunnyCoreClient.WithAccessKey(
    Environment.GetEnvironmentVariable("BUNNY_API_KEY")!);
var zones = await core.DnsZone.PublicIndexAsync();

using var storage = BunnyStorageClient.WithApiKey(
    Environment.GetEnvironmentVariable("BUNNY_STORAGE_PASSWORD")!,
    baseUrl: "https://storage.bunnycdn.com");

using var file = File.OpenRead("photo.jpg");
await storage.ManageFiles.PutAsync("my-zone", "images/holidays", "photo.jpg", file);

using var download = await storage.ManageFiles.GetAsync("my-zone", "images/holidays", "photo.jpg");
using var destination = File.Create("downloaded.jpg");
await download.CopyToAsync(destination);

// An empty path addresses the storage zone root.
var files = await storage.BrowseFiles.GetAsync("my-zone", "");

using var stream = BunnyStreamClient.WithApiKey(
    Environment.GetEnvironmentVariable("BUNNY_STREAM_API_KEY")!);
var videos = await stream.ManageVideos.VideoListAsync(123);
```

Uploads send raw bytes. The caller owns the upload stream and must dispose it.
Downloads return a stream without first buffering the entire response; dispose
that stream after reading it. Storage directory segments are individually
URL-encoded, preserving nested paths.

All factories accept a `baseUrl` override and an optional `ILogger`. You can also
pass a configured `HttpClient` to any client's constructor. Set its base address
with a trailing slash, including `/mc/` for Magic Containers. This supports
custom handlers and headers such as Storage's optional `Checksum` header.
The caller owns an injected `HttpClient`.

Origin Errors additionally exposes `WithJwtAuth`, which sends the JWT as the raw
`Authorization` header value, as specified by that API.

## Changes in 1.0.1

Resource clients implement their matching interfaces across all eight APIs.
Integer enums serialize as JSON numbers, and enum members use names from the
schema's `x-enumNames` metadata. Nullable schema references now produce typed
properties, including `DnsRecordTypes?` for DNS add/update requests.

When upgrading from 1.0.0, replace `DnsRecordTypes.__0` or integer request values
with `DnsRecordTypes.A` (or explicitly cast an integer to `DnsRecordTypes`). Other
numeric enums can also have new member names. For example:

```csharp
using Apigen.Bunny.Core;
using Apigen.Bunny.Core.Models;

using var core = BunnyCoreClient.WithAccessKey(
    Environment.GetEnvironmentVariable("BUNNY_API_KEY")!);
IDnsZoneClient dns = core.DnsZone;
await dns.PublicAddRecordAsync(42, new()
{
    Type = DnsRecordTypes.A,
    Name = "www",
    Value = "192.0.2.1"
});
```

Leaving `Type` null omits it from the request; assigning `A` sends `"Type":0`.

## Regeneration

The [superproject](https://github.com/apigen-dotnet/apigen-dotnet) pins the
matching generator and client commits. Clone it with submodules to regenerate:

```bash
git clone --recurse-submodules https://github.com/apigen-dotnet/apigen-dotnet.git
cd apigen-dotnet
./generate-all.sh bunny
```

The **Update OpenAPI Spec** workflow refreshes the eight source documents using
`specs/upstream.toml`, following the shared client workflow. Checked-in specs stay
as published upstream; regeneration works offline from these files.

The generator discovers C# `ISpecPatch` implementations in `specs/patches/` and
applies repeatable corrections in memory: a missing Logging server URL, binary
response schemas for Storage downloads and legacy CDN logs, and a missing Origin
Errors tag. An early patch removes the extraneous `uuid` path parameter on Edge
Scripting's current-code publish route before validation. The corrected document
must still pass normal OpenAPI validation.

Shield already has distinct request/response schemas, so it uses `SingleModel`
generation to retain models referenced by response properties. Response wrapper
inference is disabled because Bunny's named response schemas include their own
envelopes. Common route prefixes are preserved, including `/compute` and
Storage's zone and directory parameters. Generated source is never edited by hand.

## Build and verification

From this package directory:

```bash
dotnet test --configuration Release
./tools/verify-package.sh
```

The xUnit tests check HTTP behavior with fake handlers and verify that every
operation in the source specs has a generated method. The package verification
script uses the .NET CLI to pack and restore into an isolated NuGet cache, then
runs those tests against the `.nupkg`, including checks for bundled assemblies
and dependencies.

## License

MIT — see [LICENSE](LICENSE).
