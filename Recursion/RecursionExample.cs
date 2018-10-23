namespace Recursion
{
    public class RecursionExample
    {
        /// <summary>
        /// Sums numbers in a length
        /// </summary>
        /// <param name="a">Initial number</param>
        /// <param name="length">Amount of incremental numbers to add</param>
        /// <returns>Sum</returns>
        public int SumLength(int a, int length)
        {
            return length > 0 ? SumLength(a + 1, length) : a;
        }
    }
}