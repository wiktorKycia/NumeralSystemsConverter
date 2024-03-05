namespace NumeralSystemsConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ToDecimal(537, 8));
        }
        static int ToDecimal(int number, byte system)
        {
            int sum = 0;
            int len = (int)Math.Log10(number) +1;
            for (int i = 0; i < len; i++)
            {
                int a = (int)(number % Math.Pow(10, i+1));
                a -= (int)(number % Math.Pow(10, i));
                a /= (int)Math.Pow(10, i);
                sum += (int)(a * Math.Pow((double)system, i));
            }
            return sum;
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
