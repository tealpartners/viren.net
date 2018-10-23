using System;
using Viren.Client.Execution.Clients;
using Viren.Client.Execution.Core.Clients;
using Environment = Viren.Client.Execution.Core.Enums.Environment;

namespace Viren.Client.Execution
{
    public class ExecutionClient : BaseClient
    {
        public ExecutionClient(string publicKey, string secretKey, string virenDomain, string auth0Domain) : base(publicKey, secretKey, virenDomain, auth0Domain)
        {
            Calculation = new CalculationClient(this);
            Model = new ModelClient(this);
        }

        public ExecutionClient(string publicKey, string secretKey, Environment environment) : this(publicKey, secretKey, GetVirenDomain(environment), GetAuth0Domain(environment))
        {
        }

        public CalculationClient Calculation { get; }
        public ModelClient Model { get; }


        protected static string GetVirenDomain(Environment environment)
        {
            switch (environment)
            {
                case Environment.Production:
                    return "https://execution.viren.be";
                case Environment.Acceptance:
                    return "https://execution-acc.viren.be";
                case Environment.Develop:
                    return "https://execution-dev.viren.be";
                case Environment.Local:
                    return "http://dev.calc-exec.be";
                default:
                    throw new ArgumentOutOfRangeException(nameof(environment), environment, null);
            }
        }
    }
}