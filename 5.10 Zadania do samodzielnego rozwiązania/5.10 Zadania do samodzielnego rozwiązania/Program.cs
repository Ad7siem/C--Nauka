using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._10_Zadania_do_samodzielnego_rozwiązania
{
    class Program
    {
        static void Temperatura(double x)
        {
            double wynik;
            wynik = ((5.0 / 9.0) * (x - 32.0));
            Console.WriteLine("{0}F = {1}C", x, wynik);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("\tZadanie 5.1\n");
            Console.WriteLine("Proszę podać temperature w stopniach Fahrenheita: ");
            double f = double.Parse(Console.ReadLine());
            Temperatura(f);
            
            Console.ReadKey();
        }
    }
}
