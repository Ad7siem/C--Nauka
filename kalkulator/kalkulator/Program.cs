using System;

namespace kalkulator
{
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
                calculator k = new calculator(first, second, sign);
                Console.WriteLine("{1} {3} {2} = {0}", calculator.Result(k), k.first, k.second, k.sign);
                Console.Write("Czy kontynuować?(T/N): ");
                or = Console.ReadLine().ToUpper();
            } while (or == "T");
        }
    }
}
