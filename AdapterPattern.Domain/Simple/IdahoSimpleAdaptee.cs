namespace AdapterPattern.Domain.Simple
{
    public class IdahoSimpleAdaptee : ISocketAdapter
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

    public class SwedishSimpleAdaptee : ISocketAdapter
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