using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetCoreWebKafkaDemo
{
    public class KafkaMessageRelay
    {
        public KafkaMessageRelay(IHubContext<KafkaHub> hubContext)
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    hubContext.Clients.All.SendAsync("test");
                    Thread.Sleep(1000);
                }
            });
        }
    }
}
