using System.Reflection;
using Akka.Actor;

namespace Core.Actors;

public class BaseActor:ReceiveActor
{
    
    protected static void Publish(object @object) => Context.System.EventStream.Publish(@object);

    
}