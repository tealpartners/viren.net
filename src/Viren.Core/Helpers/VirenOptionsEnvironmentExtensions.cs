using System;
using Environment = Viren.Core.Enums.Environment;

namespace Viren.Core.Helpers
{
    public static class VirenOptionsEnvironmentExtensions
    {
        public static VirenExecutionOptions UseProduction(this VirenExecutionOptions options, string clientId, string clientSecret)
        {
            return options.Use(clientId, clientSecret, "https://execution.viren.be", "https://teal-calculation.eu.auth0.com");
        }

        public static VirenExecutionOptions UseAcceptance(this VirenExecutionOptions options, string clientId, string clientSecret)
        {
            return options.Use(clientId, clientSecret, "https://execution-acc.viren.be", "https://teal-calculation-acc.eu.auth0.com");
        }

        public static VirenExecutionOptions UseDevelopment(this VirenExecutionOptions options, string clientId, string clientSecret)
        {
            return options.Use(clientId, clientSecret, "https://execution-dev.viren.be", "https://teal-calculation-dev.eu.auth0.com");
        }

        public static VirenExecutionOptions UseLocal(this VirenExecutionOptions options, string clientId, string clientSecret)
        {
            return options.Use(clientId, clientSecret, "http://dev.calc-exec.be", "https://teal-calculation-dev.eu.auth0.com");
        }

        public static VirenExecutionOptions Use(this VirenExecutionOptions options, string clientId, string clientSecret, string baseUrl,
            string authority)
        {
            options.ClientId = clientId;
            options.ClientSecret = clientSecret;
            options.BaseUrl = baseUrl;
            options.Authority = authority;
            return options;
        }


        public static VirenExecutionOptions UseEnvironment(this VirenExecutionOptions options, Environment environment, string clientId, string clientSecret)
        {
            switch (environment)
            {
                case Environment.Production:
                    return options.UseProduction(clientId, clientSecret);
                case Environment.Acceptance:
                    return options.UseAcceptance(clientId, clientSecret);
                case Environment.Develop:
                    return options.UseDevelopment(clientId, clientSecret);
                case Environment.Local:
                    return options.UseLocal(clientId, clientSecret);
                default:
                    throw new Exception($"Environment '{environment}', does not exist.");
            }
        }
    }
}