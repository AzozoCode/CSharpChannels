namespace System.Threading.Channel.Api.Services;

public class ChannelBackgroundService(ChannelService<int> channelService):BackgroundService
{
    
    
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (await channelService.WaitForTheNextRead(stoppingToken))
        {
            var item = await channelService.DequeueAsync(stoppingToken);
            Console.WriteLine("Reader 1 Processing value => {0}",item);
        }
    }
    
}


public class ChannelBackgroundService2(ChannelService<int> channelService):BackgroundService
{
    
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (await channelService.WaitForTheNextRead(stoppingToken))
        {
            var item = await channelService.DequeueAsync(stoppingToken);
            Console.WriteLine("Reader 2 Processing value => {0}",item);
            
        }
    }
}