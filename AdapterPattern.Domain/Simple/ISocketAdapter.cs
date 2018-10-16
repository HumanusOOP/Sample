namespace AdapterPattern.Domain.Simple
{
    public interface ISocketAdapter
    {
        double GetCurrent();
        double GetVoltage();
        double GetFrequency();
    }
}