using System.Collections.Generic;
using System.Net.Http;
using Apigen.Generator;
using Microsoft.OpenApi;

public class AddMissingResponseMetadata : ISpecPatch
{
  public string Name => "Add missing Bunny download schemas, logging server and origin-error tag";

  public bool Apply(OpenApiDocument document)
  {
    if (document.Paths == null) return false;
    bool changed = AddBinaryResponse(document, "/{storageZoneName}/{path}/{fileName}");
    changed |= AddBinaryResponse(document, "/{date}/{pullZoneId}.log");

    if (document.Paths.ContainsKey("/{date}/{pullZoneId}.log") && document.Servers is not { Count: > 0 })
    {
      document.Servers = new List<OpenApiServer> { new() { Url = "https://logging.bunnycdn.com" } };
      changed = true;
    }

    if (document.Paths.TryGetValue("/{pullZoneId}/{dateTime}", out var path) &&
        path.Operations != null && path.Operations.TryGetValue(HttpMethod.Get, out var operation) &&
        operation.Tags is not { Count: > 0 })
    {
      document.Tags ??= new HashSet<OpenApiTag>();
      document.Tags.Add(new OpenApiTag { Name = "OriginErrors" });
      operation.Tags = new HashSet<OpenApiTagReference> { new("OriginErrors", document) };
      changed = true;
    }
    return changed;
  }

  private static bool AddBinaryResponse(OpenApiDocument document, string route)
  {
    if (!document.Paths.TryGetValue(route, out var path) || path.Operations == null ||
        !path.Operations.TryGetValue(HttpMethod.Get, out var operation) || operation.Responses == null ||
        !operation.Responses.TryGetValue("200", out var response) || response is not OpenApiResponse concrete ||
        concrete.Content is { Count: > 0 })
      return false;

    concrete.Content = new Dictionary<string, IOpenApiMediaType>
    {
      ["application/octet-stream"] = new OpenApiMediaType
      {
        Schema = new OpenApiSchema { Type = JsonSchemaType.String, Format = "binary" }
      }
    };
    return true;
  }
}
