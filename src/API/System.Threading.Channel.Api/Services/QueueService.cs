using System.Threading.Channels;

namespace System.Threading.Channel.Api.Services;

public class QueueService<T>
{

    private readonly Channel<T> _channel = Channels.Channel.CreateUnbounded<T>(new UnboundedChannelOptions()
    {
        SingleReader = false,
        SingleWriter = true
    });


    public bool Enqueue(T item)
    {
       return _channel.Writer.TryWrite(item);
    }


    public ValueTask<T> DequeueAsync(CancellationToken cancellationToken)
    {
        return _channel.Reader.ReadAsync(cancellationToken);
    }


    public ValueTask<bool> WaitForTheNextRead(CancellationToken cancellationToken = default)
    {
        return _channel.Reader.WaitToReadAsync(cancellationToken);
    }
}