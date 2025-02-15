namespace System.Threading.Channel.Api.Services;

public class ChannelBackgroundService(QueueService<int> queueService):BackgroundService
{
    
    
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (await queueService.WaitForTheNextRead(stoppingToken))
        {
            var item = await queueService.DequeueAsync(stoppingToken);
            Console.WriteLine("Processing value => {0}",item);
        }
    }
}