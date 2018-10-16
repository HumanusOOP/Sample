namespace AdapterPattern.Domain.Better
{
    public interface IBetterBaseSocketAdapter
    {
        double GetCurrent();
        double GetVoltage();
        double GetFrequency();
    }

    public interface IBetterSocketAdapter<T> : IBetterBaseSocketAdapter
    { }
}