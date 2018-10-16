namespace AdapterPattern.Domain.Better
{
    public interface IIdahoBetterAdaptee : IBetterBaseSocketAdapter
    { }

    public class IdahoBetterAdaptee : IIdahoBetterAdaptee
    {
        public double GetCurrent()
        {
            return 15.3D;
        }

        public double GetVoltage()
        {
            return 120.1D;
        }

        public double GetFrequency()
        {
            return 60D;
        }
    }

    public interface ISwedishBetterAdaptee : IBetterBaseSocketAdapter
    { }

    public class SwedishBetterAdaptee : ISwedishBetterAdaptee
    {
        public double GetCurrent()
        {
            return 10D;
        }

        public double GetVoltage()
        {
            return 220D;
        }

        public double GetFrequency()
        {
            return 50D;
        }
    }
}