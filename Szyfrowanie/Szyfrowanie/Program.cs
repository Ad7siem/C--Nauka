using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szyfrowanie
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj wyraz do zaszyfrowania");
            string wyraz = Console.ReadLine();
            wyraz = wyraz.ToUpper();

            int wyznacznik = 0;
            string[] szyfr = { "GADERYPOLUKI", "POLITYKARENU", "KONIECMATURY", "MALINOWEBUTY", "MOTYLECUDAKI", "KALINOWEMURY" };
            string tekstZaszyfrowany = String.Empty;

            Console.WriteLine("Który użyć szyfr?");
            for (int i = 0; i < szyfr.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, szyfr[i]);
            }
            int k = int.Parse(Console.ReadLine()) - 1;

            for (int i = 0; i < wyraz.Length; i++)
            {
                for (int j = 0; j < szyfr[k].Length; j++)
                {
                    if (wyraz[i].Equals(szyfr[k][j]) == true)
                    {
                        if (j % 2 == 0)
                        {
                            wyznacznik += 1;
                            tekstZaszyfrowany += szyfr[k][j + 1];
                            break;
                        }
                        else if (j % 2 != 0)
                        {
                            wyznacznik -= 1;
                            tekstZaszyfrowany += szyfr[k][j - 1];
                            break;
                        }
                    }
                    else if (wyraz[i].Equals(szyfr[k][j]) == false)
                    {
                        wyznacznik = 0;
                    }
                }
                if (wyznacznik == 0)
                {
                    tekstZaszyfrowany += wyraz[i];
                }
                wyznacznik = 0;
            }

            Console.WriteLine(tekstZaszyfrowany);

            Console.ReadKey();
        }
    }
}
