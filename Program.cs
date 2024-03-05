namespace NumeralSystemsConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ToDecimal("123,123", 10);
        }
        static int ToDecimal(int number, byte system)
        {

        }

        static double ToDecimal(string number, byte system)
        {
            if(system > 9)
            {
                throw new ArgumentException("Wartość systemu liczbowego nie może być większa lub równa 10!");
            }
            if (number.Contains(".") || number.Contains(","))
            {
                int dotIndex = number.IndexOf('.');
                if (dotIndex == -1)
                {
                    dotIndex = number.IndexOf(",");
                }
            }
            return 0.0;
        }
    }
}
