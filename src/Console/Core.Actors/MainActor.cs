using Newtonsoft.Json;

namespace Core.Actors;

public  class MainActor:BaseActor
{
    public MainActor()
    {
          ReceiveAsync<MainActorMessage>(DoProcessMessage);
    }



    private static async Task DoProcessMessage(MainActorMessage message)
    {
        try
        {
            Console.WriteLine("value:{0}",message.Message);
            await Task.CompletedTask;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}