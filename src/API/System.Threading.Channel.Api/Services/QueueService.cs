using System.Collections.Concurrent;

namespace System.Threading.Channel.Api.Services;

internal class QueueService<T>:IQueueService<T>
{
    private readonly ConcurrentQueue<T> _queue = new();


    public void Enqueue(T item)
    { 
        _queue.Enqueue(item);
    }


    public T? Dequeue()
    {
        return _queue.TryDequeue(out var result) ? result : default;
    }


    public int Count() => _queue.Count;
}


public interface IQueueService<T>
{
    void Enqueue(T item);

    T? Dequeue();

    int Count();
}