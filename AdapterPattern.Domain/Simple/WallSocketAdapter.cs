namespace AdapterPattern.Domain.Simple
{
    public class WallSocketAdapter : SwedishSimpleAdaptee, ISocketAdapter
    {
        public new double GetCurrent()
        {
            return base.GetCurrent();
        }

        public new double GetVoltage()
        {
            return base.GetVoltage();
        }

        public new double GetFrequency()
        {
            return base.GetFrequency();
        }
    }
}