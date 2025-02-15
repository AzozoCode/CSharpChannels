namespace Core.Actors;

public struct MainActorMessage(string message)
{

    public string Message { get; init; } = message;
}