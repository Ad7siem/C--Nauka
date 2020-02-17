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
        public double second { get; private set; }
        public string sign { get; private set; }
        public calculator(double numberFirst, double numberSecond, string mathematicalSign)
        {
            first = numberFirst;
            second = numberSecond;
            sign = mathematicalSign;
        }
        public double Sum()
        {
            return first + second;
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
            return 0;
        }
    }
}
