using System.Threading.Channel.Api.Actors.Messages;
using System.Threading.Channel.Api.Services;

namespace System.Threading.Channel.Api.Actors;

public class MainActor:BaseActor
{
    private readonly ChannelService<int> _channelService;
    private readonly IQueueService<int> _queueService;
    
    public MainActor(ChannelService<int> channelService, IQueueService<int> queueService)
    {
        _channelService = channelService;
        _queueService = queueService;
        ReceiveAsync<SendChannelMessage>(DoSendChannelMessage);
        ReceiveAsync<SendQueueMessage>(DoPushToQueue);
    }



    private async Task DoSendChannelMessage(SendChannelMessage message)
    {
        try
        {
            for (var i = 0; i < message.ItemCount; i++)
            {
                _channelService.Enqueue(Random.Shared.Next(1,1001));
            }

            await Task.CompletedTask;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private async Task DoPushToQueue(SendQueueMessage message)
    {
        try
        {
            for (var i = 0; i < message.ItemCount; i++)
            {
                _queueService.Enqueue(Random.Shared.Next(i,message.ItemCount));
            }

            await Task.CompletedTask;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}