# .NET 10.0 Upgrade Plan

## Execution Steps

Execute steps below sequentially one by one in the order they are listed.

1. Validate that an .NET 10.0 SDK required for this upgrade is installed on the machine and if not, help to get it installed.
2. Ensure that the SDK version specified in global.json files is compatible with the .NET 10.0 upgrade.
3. Upgrade PyrotechUtilities\PyrotechUtilities.csproj
4. Upgrade PyrotechUtilities\PyrotechUtilities.Tests.csproj
5. Run unit tests to validate upgrade in the projects listed below:
  PyrotechUtilities\PyrotechUtilities.Tests.csproj

## Settings

This section contains settings and data used by execution steps.

### Excluded projects

| Project name                                   | Description                 |
|:-----------------------------------------------|:---------------------------:|

### Aggregate NuGet packages modifications across all projects

### Project upgrade details

#### PyrotechUtilities\PyrotechUtilities.csproj modifications

Project properties changes:
  - Target frameworks should be changed from `netstandard2.1;net6.0;net7.0;net8.0` to `netstandard2.1;net6.0;net7.0;net8.0;net10.0`

#### PyrotechUtilities\PyrotechUtilities.Tests.csproj modifications

Project properties changes:
  - Target framework should be changed from `net8.0` to `net10.0`
