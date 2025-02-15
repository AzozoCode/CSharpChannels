
using System.Threading.Channels;

namespace Core.Channel;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var channel = System.Threading.Channels.Channel.CreateUnbounded<int>();
        using var cancellationToken = new CancellationTokenSource();
        
      var producer =  Task.Run(async() =>
        { 
           await ChannelService.ProduceAsync(channel);
        }, cancellationToken.Token);

       var consumer = Task.Run(async () =>
        {
            await ChannelService.ConsumeAsync(channel);
        },cancellationToken.Token);

        await Task.WhenAll(producer,consumer);
    }
}