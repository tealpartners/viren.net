using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Viren.Core.Enums;
using Viren.Core.Helpers;
using Viren.Execution.Requests;
using Viren.Execution.Requests.Calculations;
using Viren.Execution.Requests.Clients;
using Viren.Execution.Requests.Optimize;

namespace Viren.Execution.Clients
{
    public interface IClientClient
    {
        Task<SetWebHookResponse> RegisterWebHook(SetWebHookRequest request);
        Task<ResetWebHookResponse> ResetWebHook(ResetWebHookRequest request);
        Task<GetWebHookResponse> GetWebHook();
    }

    public class ClientClient : IClientClient
    {
        private readonly HttpClient _client;
        private readonly IModelClient _modelClient;

        public ClientClient(HttpClient client, IModelClient modelClient)
        {
            _client = client;
            _modelClient = modelClient;
        }
        
        public Task<SetWebHookResponse> RegisterWebHook(SetWebHookRequest request)
        {
            return _client.Put<SetWebHookRequest, SetWebHookResponse>($"{RoutePrefix.Client}/webhook", request);
        }   
        
        public Task<ResetWebHookResponse> ResetWebHook(ResetWebHookRequest request)
        {
            return _client.Delete<ResetWebHookRequest, ResetWebHookResponse>($"{RoutePrefix.Client}/webhook", request);
        }    
        
        public Task<GetWebHookResponse> GetWebHook()
        {
            return _client.Get<GetWebHookResponse>($"{RoutePrefix.Client}/webhook");
        }
    }
}