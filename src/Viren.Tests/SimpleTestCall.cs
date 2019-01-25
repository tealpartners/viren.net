using System;
using Microsoft.Extensions.Configuration;
using Viren.Execution;
using Xunit;

namespace Viren.Tests
{
    public class TestSettings
    {
        public string apiHostName { get; set; } 
        public string auth0Domain { get; set; }
        public string auth0TestsClientId { get; set; }
        public string auth0TestsClientSecret { get; set; }

        public override string ToString()
        {
            return $"{apiHostName} {auth0Domain} {auth0TestsClientId} {auth0TestsClientSecret}";
        }
    }
    
    public class SimpleTestCall
    {

        private TestSettings _testSettings;
        
        public SimpleTestCall()
        {
            //https://xunit.github.io/docs/comparisons
            //	We believe that use of [SetUp] is generally bad. However, you can implement a parameterless constructor as a direct replacement. See Note 2
            
            var config=new ConfigurationBuilder()
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
            Console.WriteLine(_testSettings);
            var apiHostName = _testSettings.apiHostName; // "http://dev.calc-exec.be/" ;

            var auth0Domain = _testSettings.auth0Domain;// "https://teal-calculation-dev.eu.auth0.com";
           var auth0TestsClientId= _testSettings.auth0TestsClientId; // "Hekmz983EKNcZTh5kETQqChZtUnuDXwe";
           var auth0TestsClientSecret = _testSettings.auth0TestsClientSecret; // "9TPXNqylBXydE2H20QFxQc6lGy6MShk9nAxsr8LwH6E-klpLyNzPgoRcrPGSRGm5";
            
            
            var httpClient = VirenHttpClientFactory.Create(auth0TestsClientId, auth0TestsClientSecret, apiHostName,auth0Domain);
            var client = new ExecutionClient(httpClient);

            try
            {
                var version = await client.Model.GetVersion("TestProject", "TestModel",false);
                Assert.NotNull(version);
            }
            catch (Exception e) when (e.Message.Contains("you don't have enough rights you need to have"))
            {
                Assert.True(true);    //rechten issue, maar API call is gelukt
            }
        }
    }
}