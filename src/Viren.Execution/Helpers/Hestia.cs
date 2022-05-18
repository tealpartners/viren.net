using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Viren.Execution.Clients;
using Viren.Execution.Requests.Calculations;

[assembly:InternalsVisibleTo("Viren.Tests")]
namespace Viren.Execution.Helpers
{
    /// <summary>
    ///  Hestia is the protector of the household. She shall protect us against brute force and other unsavory business.
    /// </summary>
    internal static class Hestia
    {
        private const int MaxWaitTime = 100;
        static object Lock = new object();
        

        private static readonly List<WorkItem> WorkList = new List<WorkItem>();

        /// <summary>
        /// We batch multiple request to one API call per 1 second
        /// This will decrease the overhead and improve the globally throughput
        /// </summary>
        internal static async Task<ExecuteCalculationsResponse> Protect(ExecuteCalculationsRequest request, CalculationClient calculationClient)
        {
            var localWorkItem = new WorkItem(request);
            
            lock (Lock)
            {
                WorkList.Add(localWorkItem);
            }

            await Task.WhenAny(Task.Delay(MaxWaitTime));

            if (localWorkItem.Response == null)
            {
                WorkItem[] localWork;
                lock (Lock)
                {
                    localWork = WorkList.ToArray();
                    WorkList.Clear();
                    
                }

                if (localWork.Any())
                {
                    await BatchWork(localWork, calculationClient);
                }
            }

            if (localWorkItem.Response == null)
            {
                await Task.WhenAny(Task.Delay(MaxWaitTime));
            }

            return localWorkItem.Response ?? throw new NullReferenceException();
        }

        private static async Task BatchWork(WorkItem[] localWork, CalculationClient calculationClient)
        {
            var batchRequest = new ExecuteCalculationsRequest();

            var calculations = 0;
            for (var index = 0; index < localWork.Length; index++)
            {
                var workItem = localWork[index];

                if (index == 0)
                {
                    batchRequest.ClientSessionId = workItem.Request.ClientSessionId;
                }


                foreach (var item in workItem.Request.BatchCalculationInputItems)
                {
                    batchRequest.BatchCalculationInputItems.Add(item);
                    calculations += 1;
                }
            }

            if (calculations == 0)
            {
                throw new InvalidOperationException();
            }
            
            var batchResponse = await calculationClient.ExecuteInternal(batchRequest);
            if (calculations != batchResponse.BatchCalculationOutputItems.Count)
            {
                throw new InvalidDataException(
                    $"Viren has returned {batchResponse.BatchCalculationOutputItems.Count} but we expect {calculations} calculations");
            }

            var processedItems = 0;

            foreach (var workItem in localWork)
            {
                var inputCount = workItem.Request.BatchCalculationInputItems.Count;
                workItem.Response = new ExecuteCalculationsResponse()
                {
                    ValidationMessages = batchResponse.ValidationMessages,
                    ElapsedMilliseconds = batchResponse.ElapsedMilliseconds,
                    BatchCalculationOutputItems = batchResponse.BatchCalculationOutputItems.Skip(processedItems)
                        .Take(inputCount).ToList()
                };

                processedItems += inputCount;
            }
        }
    }

    class WorkItem
    {
        
        public ExecuteCalculationsRequest Request { get; set; }

        public ExecuteCalculationsResponse Response { get; set; }

        public WorkItem(ExecuteCalculationsRequest request)
        {
            Request = request;
        }
    }
}