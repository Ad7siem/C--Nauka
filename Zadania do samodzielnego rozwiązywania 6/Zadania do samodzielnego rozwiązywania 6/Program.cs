using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania_do_samodzielnego_rozwiązywania_6
{
    class Prostokat
    {
        private int dlugosc { get; set; }
        private int szerokosc { get; set; }
        private int obwod()
        {
            return (2 * dlugosc) + (2 * szerokosc);
        }
        private int powierzchnia()
        {
            return (dlugosc * szerokosc);
        }
        public Prostokat(int dl, int sze)
        {
            dlugosc = dl;
            szerokosc = sze;
        }
        public void Prezentuj()
        {
            Console.WriteLine("Obwód prostokąta wynosi {0, 4}, a powierzchnia wynosi {1, 4}", obwod(), powierzchnia());
        }
        public void Wypisz()
        {
            Console.WriteLine("dlugosc = {0}, szerokosc = {1}", dlugosc, szerokosc);
        }
        /*
         * Zadanie 6.3. 
            Uzupełnij program z poprzedniego zadania o definicję metody statycznej, która podaje powierzchnię największego prostokąta.
         */
        public static void NajwiekszyProstokat(Prostokat[] tab)
        {
            int najwiekszy = 0;
            int pole;
            for(int i = 0; i < tab.Length; i++)
            {
                pole = 2 * 4;
                if (pole > najwiekszy)
                {
                    najwiekszy = pole;
                }
            }
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tZadanie 1\n");
            Prostokat p1 = new Prostokat(2,3);
            p1.Prezentuj();
            Prostokat p2;
            p2 = new Prostokat(4, 6);
            p2.Prezentuj();

            Console.WriteLine("\n\tZadanie 2\n");
            Prostokat[] tab = new Prostokat[3];
            tab[0] = new Prostokat (2, 6);
            tab[1] = new Prostokat(3, 8);
            tab[2] = new Prostokat(2, 4);
            foreach(Prostokat p in tab)
            {
                p.Prezentuj();
                p.Wypisz();
            }

            Console.ReadKey();
        }
    }
}
