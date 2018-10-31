﻿using System;
using System.Net.Http;
using Viren.Client.Execution.Clients;
using Viren.Client.Execution.Core;
using Viren.Client.Execution.Core.Authentication;
using Viren.Client.Execution.Core.Helpers;
using Environment = Viren.Client.Execution.Core.Enums.Environment;

namespace Viren.Client.Execution
{
    public class ExecutionClient : IVirenExecutionClient
    {
        private ExecutionClient(VirenExecutionOptions options)
        {
            var auth0HttpClient = new HttpClient {BaseAddress = new Uri(options.Authority)};

            var auth0TokenClient = new Auth0TokenClient(auth0HttpClient);
            var accessTokenCache = new AccessTokenCache(auth0TokenClient, options);
            var refreshTokenHandler = RefreshTokenHandler.CreateFallback(accessTokenCache);
            var virenHttpClient = new HttpClient(refreshTokenHandler);
            virenHttpClient.BaseAddress = new Uri(options.BaseUrl);

            Model = new ModelClient(virenHttpClient);
            Calculation = new CalculationClient(virenHttpClient, Model);
            InteractiveRun = new InteractiveRunClient(virenHttpClient);
        }

        public ExecutionClient(string publicKey, string secretKey, string virenDomain, string auth0Domain)
            : this(new VirenExecutionOptions {ClientId = publicKey, ClientSecret = secretKey, Authority = auth0Domain, BaseUrl = virenDomain})
        {
        }

        public ExecutionClient(string publicKey, string secretKey, Environment environment)
            : this(new VirenExecutionOptions().UseEnvironment(environment, publicKey, secretKey))
        {
        }

        public ICalculationClient Calculation { get; }
        public IModelClient Model { get; }
        public IInteractiveRunClient InteractiveRun { get; }
    }
}