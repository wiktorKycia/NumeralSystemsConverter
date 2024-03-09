namespace NumeralSystemsConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ToDecimal("0,4231", 5));
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
            double result;
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
                result = ToDecimal(int.Parse(number.Substring(0, dotIndex)), system);
                string afterComma = number.Substring(dotIndex + 1);
                int a = ToDecimal(int.Parse(afterComma), system);
                result += a * Math.Pow(system, -afterComma.Length);
            }
            else
            {
                result = ToDecimal(int.Parse(number), system);
            }
            return result;
        }
        static int FromDecimal(int number, byte system)
        {
            int sum = 0;
            int i = 0;
            while (number > 0)
            {
                sum += (number % system) * (int)Math.Pow(10, i);
                number /= system;
            }
            return sum;
        }
        static double AfterComma(double number, byte system, byte digitsAfterComma)
        {
            double sum = 0;
            int i = 0;
            while (number > 0 && i + 1 < digitsAfterComma)
            {
                double digit = number * system;
                sum += digit.ToString()[0] * Math.Pow(10, -i);
                number = digit % 1;
                i++;
            }
            return sum;
        }
        static double FromDecimal(string number, byte system, byte digitsAfterComma)
        {
            double result;
            if(system > 9)
            {
                throw new ArgumentException("Wartość systemu liczbowego nie może być większa lub równa 10!")
            }
            if (number.Contains('.') || number.Contains(','))
            {
                int dotIndex = number.IndexOf(".");
                if (dotIndex == -1)
                {
                    dotIndex = number.IndexOf(",");
                }
                result = ToDecimal(int.Parse(number.Substring(0, dotIndex)), system);
                string afterComma = number.Substring(dotIndex + 1);
            }
            else
            {
                result = FromDecimal(int.Parse(number), system);
            }
            return result;
        }
    }
}
