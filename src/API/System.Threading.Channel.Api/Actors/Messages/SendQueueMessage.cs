namespace System.Threading.Channel.Api.Actors.Messages;

public struct SendQueueMessage(int itemCount)
{
    public int ItemCount { get; set; } = itemCount;

}