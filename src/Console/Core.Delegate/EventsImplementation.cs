namespace Core.Delegate;

public class EventsImplementation
{
    private EventHandler _eventHandler;
     

    public EventsImplementation()
    {
        var customEventArgs = new CustomEventArgs();
        _eventHandler(this,customEventArgs);
        
    }
}