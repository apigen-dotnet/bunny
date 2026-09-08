using System.Linq;
using System.Net.Http;
using Apigen.Generator;
using Microsoft.OpenApi;

public class FixPublishReleaseParameter : ISpecPatch
{
  public string Name => "Remove release UUID from the current-code publish route";
  public bool ApplyBeforeValidation => true;

  public bool Apply(OpenApiDocument document)
  {
    if (document.Paths == null ||
        !document.Paths.TryGetValue("/compute/script/{id}/publish", out var path) ||
        path.Operations == null || !path.Operations.TryGetValue(HttpMethod.Post, out var operation) ||
        operation.Parameters == null)
      return false;

    // The sibling /publish/{uuid} route selects a release; this route publishes current code.
    var parameters = operation.Parameters.Where(p => p.In == ParameterLocation.Path && p.Name == "uuid").ToList();
    foreach (var parameter in parameters)
      operation.Parameters.Remove(parameter);
    return parameters.Count > 0;
  }
}
