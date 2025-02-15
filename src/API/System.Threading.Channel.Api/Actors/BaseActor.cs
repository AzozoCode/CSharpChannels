using Akka.Actor;

namespace System.Threading.Channel.Api.Actors;

public class BaseActor:ReceiveActor
{

    protected static void Publish(object @object)
    {
        Context.Dispatcher.EventStream.Publish(@object);
    }
}