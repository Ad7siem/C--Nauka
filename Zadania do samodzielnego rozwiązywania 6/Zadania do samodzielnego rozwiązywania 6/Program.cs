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
        private int szerokosc;
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
            }
            Console.ReadKey();
        }
    }
}
