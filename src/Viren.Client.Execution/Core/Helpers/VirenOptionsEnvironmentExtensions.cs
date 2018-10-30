using System;
using Environment = Viren.Client.Execution.Core.Enums.Environment;

namespace Viren.Client.Execution.Core.Helpers
{
    public static class VirenOptionsEnvironmentExtensions
    {
        public static VirenOptions UseProduction(this VirenOptions options, string clientId, string clientSecret)
        {
            return options.Use(clientId, clientSecret, "https://execution.viren.be", "https://teal-calculation.eu.auth0.com");
        }

        public static VirenOptions UseAcceptance(this VirenOptions options, string clientId, string clientSecret)
        {
            return options.Use(clientId, clientSecret, "https://execution-acc.viren.be", "https://teal-calculation-acc.eu.auth0.com");
        }

        public static VirenOptions UseDevelopment(this VirenOptions options, string clientId, string clientSecret)
        {
            return options.Use(clientId, clientSecret, "https://execution-dev.viren.be", "https://teal-calculation-dev.eu.auth0.com");
        }

        public static VirenOptions UseLocal(this VirenOptions options, string clientId, string clientSecret)
        {
            return options.Use(clientId, clientSecret, "http://dev.calc-exec.be", "https://teal-calculation-dev.eu.auth0.com");
        }

        public static VirenOptions Use(this VirenOptions options, string clientId, string clientSecret, string baseUrl,
            string authority)
        {
            options.ClientId = clientId;
            options.ClientSecret = clientSecret;
            options.BaseUrl = baseUrl;
            options.Authority = authority;
            return options;
        }


        public static VirenOptions UseEnvironment(this VirenOptions options, Environment environment, string clientId, string clientSecret)
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