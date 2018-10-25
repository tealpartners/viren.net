[![Build status](https://tealpartners.visualstudio.com/Viren.Net%20Client/_apis/build/status/Viren.Net-CI)](https://tealpartners.visualstudio.com/Viren.Net%20Client/_build/latest?definitionId=76)
[![NuGet version](https://badge.fury.io/nu/Viren.Client.Execution.svg)](https://badge.fury.io/nu/Viren.Client.Execution)

# Viren.NET
.NET client for the Viren API 

## Examples

### Execute calculation
```var client = new ExecutionClient(clientId, clientSecret, Environment.Production);
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
    EntryPoint = "RootBlock"
};
var calculation = client.Calculation.Execute(request);
calculation.Wait();
return calculation.Result.Result;
```

### Get tables from model
```var client = new ExecutionClient(clientId, clientSecret, Environment.Production);
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
            
