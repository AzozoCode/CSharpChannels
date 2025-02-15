using Newtonsoft.Json;

namespace Core.Actors;

public class MainActor:BaseActor
{
    public MainActor()
    {
          ReceiveAsync<MainActorMessage>(DoProcessMessage);
    }



    private async Task DoProcessMessage(MainActorMessage message)
    {
        try
        {
            Console.WriteLine("value:{0}",message.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}