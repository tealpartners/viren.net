using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Viren.Execution;
using Viren.Execution.Requests.Calculations;
using Xunit;

namespace Viren.Tests
{

    public class SimpleTestCall
    {
        private TestSettings _testSettings;

        private static string Project = "VirenDotNetProject";
        private static string Model = "VirenDotNetModel";
        private static int Version = 0;

        public SimpleTestCall()
        {
            //https://xunit.github.io/docs/comparisons
            //	We believe that use of [SetUp] is generally bad. However, you can implement a parameterless constructor as a direct replacement. See Note 2

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            _testSettings = new TestSettings();

            config
                .GetSection("AppSettings")
                .Bind(_testSettings);
        }


        [Fact]
        public async void ModelGetVersion()
        {
            var client = CreateClient();

            var version = await client.Model.GetVersion(Project, Model, false);
            Assert.NotNull(version);
        }
        
        
        [Fact]
        public async Task DocumentationBlocks()
        {
            var client = CreateClient();

            var blocksResponse = await client.Documentation
                .GetBlocksDocumentation(Project, Model, Version, "En", true);
            Assert.NotNull(blocksResponse);
            
            var firstBlock = blocksResponse.Blocks.FirstOrDefault();

            Assert.NotNull(firstBlock);
            var blockDetailResponse = await client.Documentation
                .GetBlocksDetailDocumentation(Project, Model, 1, new List<string> {firstBlock.Id}, "En", true);
            Assert.NotNull(blockDetailResponse);
            Assert.Empty(blockDetailResponse.ValidationBag.Messages);
            Assert.NotNull(blockDetailResponse.Blocks);
            Assert.NotEmpty(blockDetailResponse.Blocks);
            
            var typesResponse = await client.Documentation
                .GetTypesDocumentation(Project, Model, Version, "nl", true);
            Assert.NotNull(typesResponse);
            Assert.NotNull(typesResponse.Types);
            Assert.NotEmpty(typesResponse.Types);
        }


        [Fact]
        public async Task Calculate()
        {
            var client = CreateClient();

            var globals = new Dictionary<string, object>();
            var root = new Dictionary<string, object>
            {
                { "in1", 5 },
                { "in2", 7 }
            };

            var clientSessionId = Guid.NewGuid().ToString();
            var request = new ExecuteCalculationRequest()
            {
                Project = Project,
                Model = Model,
                Version = 0,
                EntryPoint = "rootblock",
                Globals = globals,
                Root = root,
                ClientSessionId = clientSessionId
            };
            var calcRes = await client.Calculation.Execute(request);

            var result = (decimal)calcRes.Result["out1"];
            Assert.Equal(12m, result);
            Assert.NotNull(calcRes);
        }

        private ExecutionClient CreateClient()
        {
            Console.WriteLine(_testSettings);
            
            var apiHostName = _testSettings.ApiHostName;
            var clientSecret = _testSettings.ClientSecret;
            var trustKey = _testSettings.TrustKey;

            var httpClient = VirenHttpClientFactory.Create(clientSecret, apiHostName, trustKey);
            var client = new ExecutionClient(httpClient);
            return client;
        }
    }
}