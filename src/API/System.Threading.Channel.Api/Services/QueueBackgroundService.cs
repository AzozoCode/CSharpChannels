namespace System.Threading.Channel.Api.Services;

public class QueueBackgroundService(IQueueService<int> queueService):BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var data = queueService.Dequeue();

            Console.WriteLine("Processing data from queue =>{0}\nCurrentCount:{1}",data,queueService.Count());

            await Task.Delay(50,stoppingToken);
        }
    }
}