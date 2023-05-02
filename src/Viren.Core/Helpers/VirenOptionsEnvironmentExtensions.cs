using System;
using Environment = Viren.Core.Enums.Environment;

namespace Viren.Core.Helpers
{
    public static class VirenOptionsEnvironmentExtensions
    {
        public static VirenExecutionOptions UseProduction(this VirenExecutionOptions options, string clientSecret, string trustKey = null)
        {
            return options.Use(clientSecret, "https://execution.viren.be", trustKey);
        }

        public static VirenExecutionOptions UseAcceptance(this VirenExecutionOptions options, string clientSecret, string trustKey = null)
        {
            return options.Use(clientSecret, "https://execution-acc.viren.be", trustKey);
        }

        public static VirenExecutionOptions UseDevelopment(this VirenExecutionOptions options, string clientSecret, string trustKey = null)
        {
            return options.Use(clientSecret, "https://execution-dev.viren.be", trustKey);
        }

        public static VirenExecutionOptions UseLocal(this VirenExecutionOptions options, string clientSecret, string trustKey = null)
        {
            return options.Use(clientSecret, "http://dev.calc-exec.be", trustKey);
        }

        public static VirenExecutionOptions Use(this VirenExecutionOptions options, string clientSecret, string baseUrl, string trustKey = null)
        {
            options.ClientSecret = clientSecret;
            options.BaseUrl = baseUrl;
            options.TrustKey = trustKey;
            return options;
        }


        public static VirenExecutionOptions UseEnvironment(this VirenExecutionOptions options, Environment environment, string clientSecret, string trustKey = null)
        {
            switch (environment)
            {
                case Environment.Production:
                    return options.UseProduction(clientSecret, trustKey);
                case Environment.Acceptance:
                    return options.UseAcceptance(clientSecret, trustKey);
                case Environment.Develop:
                    return options.UseDevelopment(clientSecret, trustKey);
                case Environment.Local:
                    return options.UseLocal(clientSecret, trustKey);
                default:
                    throw new Exception($"Environment '{environment}', does not exist.");
            }
        }
    }
}