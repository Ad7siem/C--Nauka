using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kalkulator
{
    class calculator
    {
        public double first { get; private set; }
        public double second { get; private set; } = 0;
        public string sign { get; private set; }
        public calculator(double numberFirst, double numberSecond, string mathematicalSign)
        {
            first = numberFirst;
            second = numberSecond;
            sign = mathematicalSign;
        }
        private double Sum()
        {
            return first + second;
        }
        private double Difference()
        {
            return first - second;
        }
        private double Product()
        {
            return first * second;
        }
        private double Quotient()
        {
            return first / second;
        }
        private double Pow()
        {
            return Math.Pow(first, second);
        }
        private double Root()
        {
            return Math.Sqrt(first);
        }
        public static double Result(calculator k)
        {
            if (k.sign == "+")
                return k.Sum();
            else if (k.sign == "-")
                return k.Difference();
            else if (k.sign == "*")
                return k.Product();
            else if (k.sign == "/")
                return k.Quotient();
            else if (k.sign == "^")
                return k.Pow();
            else if (k.sign == "%")
                return k.Root();
            return 0;
        }
        public void Data()
        {
            Console.Write("Podaj pierwszą liczbę: ");
            first = double.Parse(Console.ReadLine());
            Console.Write("Podaj znak matematyczny: ");
            sign = Console.ReadLine();
            if (sign != "%")
            {
                Console.Write("Podaj drugą liczbę: ");
                second = double.Parse(Console.ReadLine());
            }
        }
        public static void View(calculator k)
        {
            if (k.sign != "%") Console.WriteLine("{1} {3} {2} = {0}", calculator.Result(k), k.first, k.second, k.sign);
            else Console.WriteLine("Pierwiastek z {1} = {0}", calculator.Result(k), k.first);
        }

    }
}
