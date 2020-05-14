using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Viren.Execution.Clients;
using Xunit;
using Viren.Execution.Extensions.DependencyInjection;
using Viren.Core;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Viren.Core.Helpers;

namespace Viren.Tests
{
    public class LogHttpBase<T> : DelegatingHandler //mimic payroll setup
    {
        public LogHttpBase()
        {

        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            return response;
        }
    }

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);


            var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true)
            .Build();

            var testSettings = new TestSettings();

            config
                .GetSection("AppSettings")
                .Bind(testSettings);



            services.AddVirenExecution(ops =>
            {
                ops.UseDevelopment(testSettings.auth0TestsClientId, testSettings.auth0TestsClientSecret);
            },
                extendOidcHttpClient: builder => builder.AddHttpMessageHandler<LogHttpBase<VirenExecutionOptions>> (),
                extendVirenHttpClient: builder => builder.AddHttpMessageHandler<LogHttpBase<IVirenExecutionClient>>()
                );

            services.AddTransient<LogHttpBase<VirenExecutionOptions>>();
            services.AddTransient<LogHttpBase<IVirenExecutionClient>>();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
        }
    }

    public static class TestValue
    {
        public const string OkValue = "HeyHoLetsGo";
    }

    [Route("api/tests")]
    [ApiController]
    public class TestController : Controller
    {
        private readonly IVirenExecutionClient virenExecutionClient;

        public TestController(IVirenExecutionClient virenExecutionClient)
        {
            this.virenExecutionClient = virenExecutionClient;
        }

        public string Get()
        {

            try
            {
                var version = virenExecutionClient.Model.GetVersion("TestProject", "TestModel", false).ConfigureAwait(false).GetAwaiter().GetResult();
                return TestValue.OkValue;
            }
            catch (Exception e) when (e.Message.Contains("you don't have enough rights you need to have"))
            {
                return TestValue.OkValue;
            }
        }
    }

    public class WebApiDiTests
    {
        private TestSettings _testSettings;

        public WebApiDiTests()
        {
            //https://xunit.github.io/docs/comparisons
            //	We believe that use of [SetUp] is generally bad. 
            //  However, you can implement a parameterless constructor as a direct replacement. See Note 2
        }


        [Fact]
        public async void ModelGetVersionInWebApi()
        {

            var webHostBuilder = new WebHostBuilder()
                        .UseEnvironment("Test") // You can set the environment you want (development, staging, production)
                        .UseStartup<Startup>(); // Startup class of your web app project

            using (var server = new TestServer(webHostBuilder))
            using (var client = server.CreateClient())
            {
                string result = await client.GetStringAsync("/api/tests");
                Assert.Equal(TestValue.OkValue, result);
            }
        }
    }
}