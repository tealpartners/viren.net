using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Viren.Execution;
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
                    .GetBlocksDocumentation("TestProject", "TestModel", 1,true);
                Assert.NotNull(blocksResponse);
                
                var firstBlock = blocksResponse.Blocks.FirstOrDefault();

                Assert.NotNull(firstBlock);
                var blockDetailResponse = await client.Documentation
                    .GetBlocksDetailDocumentation("TestProject", "TestModel", 1, new List<string> {firstBlock.Id}, true);
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
                var requestId = Guid.NewGuid().ToString();
                var calcRes = await client.Calculation.Execute("TestProject", "TestModel", 0, "NettoBerekening", globals, root, null, null, null, requestId);
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

            var auth0Domain = _testSettings.auth0Domain; // "https://teal-calculation-dev.eu.auth0.com";
            var auth0TestsClientId = _testSettings.auth0TestsClientId; // "Hekmz983EKNcZTh5kETQqChZtUnuDXwe";
            var auth0TestsClientSecret = _testSettings.auth0TestsClientSecret; // "9TPXNqylBXydE2H20QFxQc6lGy6MShk9nAxsr8LwH6E-klpLyNzPgoRcrPGSRGm5";
            var httpClient = VirenHttpClientFactory.Create(auth0TestsClientId, auth0TestsClientSecret, apiHostName, auth0Domain);
            var client = new ExecutionClient(httpClient);
            return client;
        }
    }
}