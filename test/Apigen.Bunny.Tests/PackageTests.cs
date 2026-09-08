#if PACKAGE_REFERENCE
using System.IO.Compression;
using System.Xml.Linq;

namespace Apigen.Bunny.Tests;

public class PackageTests
{
  [Fact]
  public void ContainsEveryClientAndModelAssembly()
  {
    var solution = XDocument.Load(Path.Combine(AppContext.BaseDirectory, "TestData", "Apigen.Bunny.slnx"));
    var expected = solution.Descendants("Project")
      .Select(project => project.Attribute("Path")!.Value)
      .Where(path => path.StartsWith("src/", StringComparison.Ordinal))
      .Select(path => $"lib/net10.0/{Path.GetFileNameWithoutExtension(path)}.dll")
      .ToHashSet();
    using var package = OpenPackage();
    var actual = package.Entries.Where(entry => entry.FullName.EndsWith(".dll", StringComparison.Ordinal))
      .Select(entry => entry.FullName).ToHashSet();
    Assert.Equal(expected.Order(), actual.Order());
  }

  [Fact]
  public void DeclaresExternalDependenciesWithoutSeparateBunnyPackages()
  {
    using var package = OpenPackage();
    using var manifest = package.GetEntry("Apigen.Bunny.nuspec")!.Open();
    var dependencies = XDocument.Load(manifest).Descendants()
      .Where(element => element.Name.LocalName == "dependency")
      .Select(element => element.Attribute("id")!.Value).ToHashSet();
    Assert.Equal(new[] { "Microsoft.Extensions.Logging.Abstractions", "System.ComponentModel.Annotations" }, dependencies.Order());
  }

  private static ZipArchive OpenPackage() =>
    ZipFile.OpenRead(Environment.GetEnvironmentVariable("BUNNY_PACKAGE_PATH")
      ?? throw new InvalidOperationException("Set BUNNY_PACKAGE_PATH to the package under test."));
}
#endif
