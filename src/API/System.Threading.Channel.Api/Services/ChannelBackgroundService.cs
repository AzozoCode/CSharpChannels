namespace System.Threading.Channel.Api.Services;

public class ChannelBackgroundService(QueueService<int> queueService):BackgroundService
{
    
    
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (await queueService.WaitForTheNextRead(stoppingToken))
        {
            var item = await queueService.DequeueAsync(stoppingToken);
            Console.WriteLine("Reader 1 Processing value => {0}",item);
        }
    }
    
}


public class ChannelBackgroundService2(QueueService<int> queueService):BackgroundService
{
    
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (await queueService.WaitForTheNextRead(stoppingToken))
        {
            var item = await queueService.DequeueAsync(stoppingToken);
            Console.WriteLine("Reader 2 Processing value => {0}",item);
        }
    }
}