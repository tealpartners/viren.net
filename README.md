[![Build status](https://tealpartners.visualstudio.com/Viren.Net%20Client/_apis/build/status/Viren.Net-CI)](https://tealpartners.visualstudio.com/Viren.Net%20Client/_build/latest?definitionId=76)
# Viren.NET
.NET client for the Viren API 

## Packages
| Package                                        | Version  |
| ---------------------------------------------- | ---------|
| Viren.Core                                     | [![NuGet version](https://badge.fury.io/nu/Viren.Core.svg)](https://badge.fury.io/nu/Viren.Core)|
| Viren.Execution                                | [![NuGet version](https://badge.fury.io/nu/Viren.Execution.svg)](https://badge.fury.io/nu/Viren.Execution) |
| Viren.Execution.Extensions.DependencyInjection | [![NuGet version](https://badge.fury.io/nu/Viren.Execution.Extensions.DependencyInjection.svg)](https://badge.fury.io/nu/Viren.Execution.Extensions.DependencyInjection) |







## Examples
### Viren namespaces and alias
```csharp
using Viren.Execution;
using Environment = Viren.Core.Enums.Environment;
```

### Creating a client
```csharp
var clientSecret = "";
var environment = Environment.Production;
var httpClient = VirenHttpClientFactory.Create(clientSecret, environment);
var executionClient = new ExecutionClient(httpClient);
```

### Execute calculation
```csharp
var request = new ExecuteCalculationRequest()
{
    Project = "Project",
    Model = "Model",
    Version = 1,
    Revision = null,
    Root = new Dictionary<string, object>
    {
        { "Input", 5 }
    },
    EntryPoint = "RootBlock",

    // Optionally specify an identifier to mark multiple calls as part of a single user session
    ClientSessionId = "my-session-identifier"
};
var calculation = client.Calculation.Execute(request);
calculation.Wait();
return calculation.Result.Result;
```


### Get tables from model
```csharp
var request = new GetLookupTablesRequest()
{
    Project = "Project",
    Model = "Model",
    Version = 1,
    Revision = null,
    GlobalIds = new []{"CarTable", "WageTable"}
};
var tables = client.Model.GetTables(request);
tables.Wait();
return tables.Result.Result;
```
            
