using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Helloworld;
// using Microsoft.Extensions.Logging;

namespace cs_grpc_test
{
    public class GreeterImpl : Greeter.GreeterBase
    {
        // Server side handler of the SayHello RPC
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply { Message = "Hello " + request.Name });
        }

        public override async Task SayStream(IAsyncStreamReader<HelloRequest> requestStream, IServerStreamWriter<HelloReply> responseStream, ServerCallContext context)
        {
            var raceDuration = TimeSpan.Parse(context.RequestHeaders.Single(h => h.Key == "race-duration").Value);

            // Read incoming messages in a background task
            HelloRequest? lastMessageReceived = null;
            // var readTask = Task.Run(async () =>
            // {
            //     await foreach (var message in requestStream.ReadAllAsync())
            //     {
            //         lastMessageReceived = message;
            //     }
            // });

            // // Write outgoing messages until timer is complete
            // var sw = Stopwatch.StartNew();
            // var sent = 0;
            // while (sw.Elapsed < raceDuration)
            // {
            //     await responseStream.WriteAsync(new HelloReply { });
            // }

            // await readTask;
        }
    }
}