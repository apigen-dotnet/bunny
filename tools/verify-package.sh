#!/bin/bash
set -euo pipefail

PACKAGE_ROOT="$(cd "$(dirname "$0")/.." && pwd)"
cd "$PACKAGE_ROOT"
PROJECT="src/Apigen.Bunny/Apigen.Bunny.csproj"
TEST_PROJECT="test/Apigen.Bunny.Tests/Apigen.Bunny.Tests.csproj"
VERSION="$(dotnet msbuild "$PROJECT" -getProperty:Version)"
PACKAGE_CACHE="$(mktemp -d)"
trap 'rm -rf "$PACKAGE_CACHE"' EXIT

dotnet pack "$PROJECT" --configuration Release --output artifacts/packages
dotnet restore "$TEST_PROJECT" -p:UsePackageReference=true -p:BunnyPackageVersion="$VERSION" \
  --packages "$PACKAGE_CACHE" --source "$PACKAGE_ROOT/artifacts/packages" --source https://api.nuget.org/v3/index.json
BUNNY_PACKAGE_PATH="$PACKAGE_ROOT/artifacts/packages/Apigen.Bunny.$VERSION.nupkg" \
  dotnet test "$TEST_PROJECT" --configuration Release --no-restore \
    -p:UsePackageReference=true -p:BunnyPackageVersion="$VERSION"
dotnet restore "$TEST_PROJECT" --verbosity quiet
