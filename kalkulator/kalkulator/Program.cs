using System;

namespace kalkulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                "#####################\n" +
                "## Suma        = + ##\n" +
                "## Różnica     = - ##\n" +
                "## Iloczyn     = * ##\n" +
                "## Iloraz      = / ##\n" +
                "## Potęga      = ^ ##\n" +
                "## Pierwiastek = % ##\n" +
                "#####################\n"
                );
            string sign = null, or = "T";
            double first = 0, second = 0;
            do
            {
                calculator k = new calculator(first, second, sign);
                k.Data();
                calculator.View(k);
                Console.Write("Czy kontynuować?(T/N): ");
                or = Console.ReadLine().ToUpper();
                Console.WriteLine();
            } while (or == "T");
            
        }
    }
}
