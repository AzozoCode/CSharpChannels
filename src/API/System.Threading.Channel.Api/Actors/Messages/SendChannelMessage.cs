namespace System.Threading.Channel.Api.Actors.Messages;

public struct SendChannelMessage(int itemCount)
{
    public int ItemCount { get; set; } = itemCount;
}