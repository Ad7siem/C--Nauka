using System;

namespace kalkulator
{
    class Kalkulator
    {
        public double first { get; private set; }
        public double second { get; private set; }
        public string sign { get; private set; }
        public Kalkulator(double numberFirst, double numberSecond, string mathematicalSign)
        {
            first = numberFirst;
            second = numberSecond;
            sign = mathematicalSign;
        }
        public double Sum()
        {
            return first + second ;
        }
        public double Difference()
        {
            return first - second;
        }
        public double Product()
        {
            return first * second;
        }
        public double Quotient()
        {
            return first / second;
        }
        public static double Result(Kalkulator k)
        {
            if (k.sign == "+")
                return k.Sum();
            else if (k.sign == "-")
                return k.Difference();
            else if (k.sign == "*")
                return k.Product();
            else if (k.sign == "/")
                return k.Quotient();
            return 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string or = "T";
            do
            {
                Console.Write("Podaj pierwszą liczbę: ");
                double first = double.Parse(Console.ReadLine());
                Console.Write("Podaj drugą liczbę: ");
                double second = double.Parse(Console.ReadLine());
                Console.Write("Podaj znak matematyczny: ");
                string sign = Console.ReadLine();
                Kalkulator k = new Kalkulator(first, second, sign);
                Console.WriteLine("{1} {3} {2} = {0}", Kalkulator.Result(k), k.first, k.second, k.sign);
                Console.Write("Czy kontynuować?(T/N): ");
                or = Console.ReadLine();
            } while (or == "T");
        }
    }
}
