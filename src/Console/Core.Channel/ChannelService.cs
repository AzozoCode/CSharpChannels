using System.Threading.Channels;
namespace Core.Channel;

public static class ChannelService
{
    

    public static async Task ProduceAsync(ChannelWriter<int> writer)
    {
        for (var i = 0; i < 10; i++)
        {
            await writer.WriteAsync(i);
            Console.WriteLine("Produced:{0}",i);
            await Task.Delay(500);
        }

        writer.Complete();
    }



    public static async Task ConsumeAsync(ChannelReader<int> reader)
    {
        await foreach (var data in reader.ReadAllAsync())
        {
            Console.WriteLine("Consumed:Item:{0}",data);
            await Task.Delay(1000);
        }
    }
}