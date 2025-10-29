# Lección 8

## Unit tests

### Library

```
dotnet new classlib -o CalcLib

dotnet sln add CalcLib

cd CalcLib

dotnet build
```

### XUnit

```
dotnet new xunit -o CalcLibUnitTests

dotnet sln add CalcLibUnitTests
```

```xml
<ItemGroup>
  <ProjectReference Include="..\CalcLib\CalcLib.csproj" />
</ItemGroup>
```

```
cd CalcLibUnitTests

dotnet test
```