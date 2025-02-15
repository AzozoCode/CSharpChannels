using System.Threading.Channel.Api.Actors.Messages;
using System.Threading.Channel.Api.Services;

namespace System.Threading.Channel.Api.Actors;

public class MainActor:BaseActor
{
    private readonly ChannelService<int> _channelService;
    
    public MainActor(ChannelService<int> channelService)
    {
        _channelService = channelService;
        ReceiveAsync<SendChannelMessage>(DoSendChannelMessage);
    }



    private async Task DoSendChannelMessage(SendChannelMessage message)
    {
        try
        {
            for (var i = 0; i < message.ItemCount; i++)
            {
                _channelService.Enqueue(Random.Shared.Next(1,1001));

                await Task.Delay(50);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}