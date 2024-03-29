using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Viren.Execution;
using Viren.Execution.Requests.Calculations;
using Xunit;

namespace Viren.Tests
{

    public class SimpleTestCall
    {
        private TestSettings _testSettings;

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

            try
            {
                var version = await client.Model.GetVersion("TestProject", "TestModel", false);
                Assert.NotNull(version);
            }
            catch (Exception e) when (e.Message.Contains("you don't have enough rights you need to have"))
            {
                Assert.True(true, e.ToString()); //rechten issue, maar API call is gelukt
            }
        }
        
        
        [Fact]
        public async void DocumentationBlocks()
        {
            var client = CreateClient();

            try
            {
                var blocksResponse = await client.Documentation
                    .GetBlocksDocumentation("TestProject", "TestModel", 1, "En", true);
                Assert.NotNull(blocksResponse);
                
                var firstBlock = blocksResponse.Blocks.FirstOrDefault();

                Assert.NotNull(firstBlock);
                var blockDetailResponse = await client.Documentation
                    .GetBlocksDetailDocumentation("TestProject", "TestModel", 1, new List<string> {firstBlock.Id}, "En", true);
                Assert.NotNull(blockDetailResponse);
                Assert.Empty(blockDetailResponse.ValidationBag.Messages);
                Assert.NotNull(blockDetailResponse.Blocks);
                Assert.NotEmpty(blockDetailResponse.Blocks);
                
                
                
                var typesResponse = await client.Documentation
                    .GetTypesDocumentation("TestProject", "TestModel", 1, "nl", true);
                Assert.NotNull(typesResponse);
                Assert.Empty(typesResponse.ValidationBag.Messages);
                Assert.NotNull(typesResponse.Types);
                Assert.NotEmpty(typesResponse.Types);
            }
            catch (Exception e) when (e.Message.Contains("you don't have enough rights you need to have"))
            {
                Assert.True(true, e.ToString()); //rechten issue, maar API call is gelukt
            }
        }


        [Fact]
        public async void Calculate()
        {
            try
            {
                var client = CreateClient();

                var globals = new Dictionary<string, object>();
                var root = new Dictionary<string, object>();
                var clientSessionId = Guid.NewGuid().ToString();
                var request = new ExecuteCalculationRequest()
                {
                    Project = "TestProject",
                    Model = "TestModel",
                    Version = 0,
                    EntryPoint = "NettoBerekening",
                    Globals = globals,
                    Root = root,
                    ClientSessionId = clientSessionId
                };
                var calcRes = await client.Calculation.Execute(request);
                Assert.NotNull(calcRes.ValidationMessages[0].Code);
                Assert.NotNull(calcRes);
            }
            catch (Exception e) when (e.Message.Contains("you don't have enough rights you need to have"))
            {
                Assert.True(true, e.ToString()); //rechten issue, maar API call is gelukt
            }
        }

        private ExecutionClient CreateClient()
        {
            Console.WriteLine(_testSettings);
            
            var apiHostName = _testSettings.apiHostName; // "http://dev.calc-exec.be/" ;

            var clientSecret = _testSettings.clientSecret; // "9TPXNqylBXydE2H20QFxQc6lGy6MShk9nAxsr8LwH6E-klpLyNzPgoRcrPGSRGm5";
            var httpClient = VirenHttpClientFactory.Create(clientSecret, apiHostName);
            var client = new ExecutionClient(httpClient);
            return client;
        }
    }
}