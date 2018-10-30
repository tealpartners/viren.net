using System;
using System.Linq;
using Environment = Viren.Client.Execution.Core.Enums.Environment;

namespace Viren.Client.Execution
{
    public static class VirenOptionsEnvironmentExtensions
    {
        public static VirenOptions UseProduction(this VirenOptions options, string clientId, string clientSecret)
            => options.Use(clientId, clientSecret, "https://execution.viren.be", "https://teal-calculation.eu.auth0.com");
        public static VirenOptions UseAcceptance(this VirenOptions options, string clientId, string clientSecret)
            => options.Use(clientId, clientSecret, "https://execution-acc.viren.be", "https://teal-calculation-acc.eu.auth0.com");
        public static VirenOptions UseDevelopment(this VirenOptions options, string clientId, string clientSecret)
            => options.Use(clientId, clientSecret, "https://execution-dev.viren.be", "https://teal-calculation-dev.eu.auth0.com");
        public static VirenOptions UseLocal(this VirenOptions options, string clientId, string clientSecret)
            => options.Use(clientId, clientSecret, "http://dev.calc-exec.be", "https://teal-calculation-dev.eu.auth0.com");

        public static VirenOptions Use(this VirenOptions options, string clientId, string clientSecret, string baseUrl,
            string authority)
        {
            options.ClientId = clientId;
            options.ClientSecret = clientSecret;
            options.BaseUrl = baseUrl;
            options.Authority = authority;
            return options;
        }
        
        
        public static VirenOptions UseEnvironment(this VirenOptions options, Core.Enums.Environment environment, string clientId, string clientSecret)
        {
            return environment == Environment.Production ? options.UseProduction(clientId, clientSecret) :
                environment == Environment.Acceptance ? options.UseAcceptance(clientId, clientSecret) :
                environment == Environment.Develop ? options.UseDevelopment(clientId, clientSecret) :
                environment == Environment.Local ? options.UseLocal(clientId, clientSecret) :
                throw new Exception($"Environment '{environment}', does not exist.");
        }
    }
}