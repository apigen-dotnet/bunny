using System.Text.Json;
using System.Text.RegularExpressions;

namespace Apigen.Bunny.Tests;

public class SpecTests
{
  private static readonly string DataPath = Path.Combine(AppContext.BaseDirectory, "TestData");
  private static readonly HashSet<string> Methods = ["get", "post", "put", "patch", "delete", "head", "options"];

  public static IEnumerable<object[]> Specifications =>
    Directory.GetFiles(Path.Combine(DataPath, "Specs"), "*.json").Select(path => new object[] { path });

  [Theory]
  [MemberData(nameof(Specifications))]
  public void EverySourceOperationHasAGeneratedMethod(string specPath)
  {
    using var spec = JsonDocument.Parse(File.ReadAllText(specPath));
    var expected = spec.RootElement.GetProperty("paths").EnumerateObject()
      .SelectMany(path => path.Value.EnumerateObject()
        .Where(operation => Methods.Contains(operation.Name))
        .Select(operation => $"{operation.Name.ToUpperInvariant()} {path.Name}"))
      .ToHashSet();

    string source = $"// Source: specs/{Path.GetFileName(specPath)}";
    var actual = Directory.GetFiles(Path.Combine(DataPath, "Interfaces"), "*.cs", SearchOption.AllDirectories)
      .Select(File.ReadAllText)
      .Where(content => content.Contains(source, StringComparison.Ordinal))
      .SelectMany(content => Regex.Matches(content, @"/// Operation: ([A-Z]+ \S+)").Select(match => match.Groups[1].Value))
      .ToHashSet();

    Assert.NotEmpty(expected);
    Assert.Equal(expected.Order(), actual.Order());
  }
}
