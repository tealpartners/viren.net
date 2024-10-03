using System;
using Environment = Viren.Core.Enums.Environment;

namespace Viren.Core.Helpers
{
    public static class VirenOptionsEnvironmentExtensions
    {
        public static VirenExecutionOptions UseProduction(this VirenExecutionOptions options, string clientSecret)
        {
            return options.Use(clientSecret, "https://execution.viren.be");
        }

        public static VirenExecutionOptions UseAcceptance(this VirenExecutionOptions options, string clientSecret)
        {
            return options.Use(clientSecret, "https://execution-acc.viren.be");
        }

        public static VirenExecutionOptions UseDevelopment(this VirenExecutionOptions options, string clientSecret)
        {
            return options.Use(clientSecret, "https://execution-dev.viren.be");
        }

        public static VirenExecutionOptions UseLocal(this VirenExecutionOptions options, string clientSecret)
        {
            return options.Use(clientSecret, "https://localhost:6300");
        }

        public static VirenExecutionOptions Use(this VirenExecutionOptions options, string clientSecret, string baseUrl, string trustKey = null)
        {
            options.ClientSecret = clientSecret;
            options.BaseUrl = baseUrl;
            options.TrustKey = trustKey;
            return options;
        }


        public static VirenExecutionOptions UseEnvironment(this VirenExecutionOptions options, Environment environment, string clientSecret)
        {
            switch (environment)
            {
                case Environment.Production:
                    return options.UseProduction(clientSecret);
                case Environment.Acceptance:
                    return options.UseAcceptance(clientSecret);
                case Environment.Develop:
                    return options.UseDevelopment(clientSecret);
                case Environment.Local:
                    return options.UseLocal(clientSecret);
                default:
                    throw new Exception($"Environment '{environment}', does not exist.");
            }
        }
    }
}