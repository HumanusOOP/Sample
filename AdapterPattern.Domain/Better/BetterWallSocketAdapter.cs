namespace AdapterPattern.Domain.Better
{
    public class BetterWallSocketAdapter<T> : IBetterSocketAdapter<T> where T : IBetterBaseSocketAdapter
    {
        private readonly T _adaptee;

        public BetterWallSocketAdapter(T adaptee)
        {
            _adaptee = adaptee;
        }

        public double GetCurrent()
        {
            return _adaptee.GetCurrent();
        }

        public double GetVoltage()
        {
            return _adaptee.GetVoltage();
        }

        public double GetFrequency()
        {
            return _adaptee.GetFrequency();
        }
    }
}
