namespace Airplane
{
    public class RecursionExample
    {
        public int SumLength(int a, int length)
        {
            if (length > 0)
                return SumLength(a + 1, length);

            else
                return a;
        }
    }
}