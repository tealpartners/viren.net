using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Viren.Execution.Clients;
using Viren.Execution.Dtos.CalculationDtos.Batch;
using Viren.Execution.Helpers;
using Viren.Execution.Requests.Calculations;
using Xunit;
using Xunit.Abstractions;

namespace Viren.Tests
{
    public class HestiaTester
    {
        private readonly ITestOutputHelper _output;
        private readonly HestiaCalculationClient Client;
        
        private static readonly Random Random = new Random();

        public HestiaTester(ITestOutputHelper output)
        {
            _output = output;
            Client = new HestiaCalculationClient(output);
        }

        [Fact]
        public async void HestiaShouldWork()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var tasks = new Task[500];
            for (var i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Run(Execute);
            }
            await Task.WhenAll(tasks);
            stopwatch.Stop();
            
            _output.WriteLine($"Executed in: {stopwatch.ElapsedMilliseconds}");
        }
        
        private void Execute()
        {
            var request = new ExecuteCalculationsRequest()
            {
                ClientSessionId = Guid.NewGuid().ToString()
            };
            
            // Random add work
            var random = Random.Next(1, 1);
            for (var i = 0; i < random; i++)
            {     
                request.BatchCalculationInputItems.Add(new BatchCalculationInputItemDto());
            }

            var task = Hestia.Protect(request, Client);
            task.Wait();
            var result = task.Result;

            result.BatchCalculationOutputItems.Count.Should().Be(random);
        }

        class HestiaCalculationClient: CalculationClient
        {
            private readonly ITestOutputHelper _output;
            private readonly List<BatchCalculationInputItemDto> Inputs = new List<BatchCalculationInputItemDto>();
            
            public HestiaCalculationClient(ITestOutputHelper testOutputHelper) : base(null)
            {
                _output = testOutputHelper;
            }
            
            internal override async Task<ExecuteCalculationsResponse> ExecuteInternal(ExecuteCalculationsRequest request)
            {
                await Task.CompletedTask;

                var random = Random.Next(10, 100);
                
                var response = new ExecuteCalculationsResponse
                {
                    ElapsedMilliseconds = random,
                    BatchCalculationOutputItems = request.BatchCalculationInputItems.Select(x => new BatchCalculationOutputItemDto
                    {
                        IsValid = true,
                        RequestId = Guid.NewGuid().ToString()
                    }).ToList()
                };

                _output.WriteLine($"{DateTime.Now.ToLongTimeString()} Hestia has batched: {request.BatchCalculationInputItems.Count} calculations");
                Thread.Sleep(random);

                return response;
            }

        }
    }
}