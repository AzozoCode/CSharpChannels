namespace Core.Delegate;

public class CustomEventArgs:EventArgs
{
    public object? ExtraData { get; set; }

    public bool HasSuperPower { get; set; }
}