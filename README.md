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
using Viren.Execution;
using Environment = Viren.Core.Enums.Environment;

### Creating a client
```
var auth0ClientId = "";
var auth0ClientSecret = "";
var environment = Environment.Production;
var httpClient = VirenHttpClientFactory.Create(auth0ClientId, auth0ClientSecret, environment);
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

### Batch calculation
```csharp
using Viren.Execution;
using Viren.Execution.Requests.Clients;
using Viren.Execution.Requests.Calculations;
using Newtonsoft.Json.Linq;

var client = new ExecutionClient(clientId, clientSecret, Viren.Core.Enums.Environment.Production);

// Optionally register webhook once to receive feedback (multiple registrations simply overwrite existing registration)
var setWebHookRequest = new SetWebHookRequest
{
    // Viren will callback on this url at /api/webhook/calculation/complete (for request content see Viren.Execution.Requests.WebHook.CalculationCompleteRequest)
    // Depending on your batch size, 1 or more calls will be made until the batch calculation has completed
    Url = "http://<your callback endpoint>/",
                
    // Optional OAuth configuration which Viren should use to request an access token to call url specified above, 
    // if not required leave TokenEndpoint and other settings empty
    TokenEndpoint = "https://<your oauth token endpoint>/",
    ClientId = "<client_id>",
    ClientSecret = "<client_secret>",
    Audience = "<audience>",
};
client.Calculation.RegisterWebHook(setWebHookRequest).Wait();

// Execute batch calculaton
var request = new ExecuteCalculationBatchRequest
{
    Inputs = new List<ExecuteCalculationBatchInput>
    {
        new ExecuteCalculationBatchInput
        {
            Project = "Project",
            Model = "Model",
            Version = 1,
            Revision = null,
            EntryPoint = "BlockName",
            CalculationInputHeaders = new List<string>{ "Input1", "Input2" },
            CalculationInputs = new List<ExecuteCalculationBatchInputItem>
            {
                new ExecuteCalculationBatchInputItem { RequestId = "<your correlation id>", Root = new List<JValue> { new JValue("Input1 value"), new JValue("Input2 value")  } }
            }
        },
        // ...optionally other models to calculate in the same batch
    }
};
var batch = client.Calculation.Batch(request);
batch.Wait();

var errors = batch.Result.ValidationMessages;
var batchId = batch.Result.BatchId;

// If webhook is registered, callbacks will contain received batch id with calculation results

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
            
