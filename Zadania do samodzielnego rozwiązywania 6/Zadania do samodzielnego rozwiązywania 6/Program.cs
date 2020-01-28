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
        public int Powierzchnia()
        {
            return powierzchnia();
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
                var polex = tab[i].Powierzchnia();
                if (polex > najwiekszy)
                {
                    najwiekszy = polex;
                }
            }
            Console.WriteLine("Największy prostokąt ma pole o wartosci: {0}", najwiekszy);
        }
    }
    class Energia
    {
        private int StanPoczatkowy;
        private int StanAktualny;
        public Energia(int SP, int SA)
        {
            StanPoczatkowy = SP;
            StanAktualny = SA;
        }
        public void Wypisz()
        {
            Console.WriteLine("Stan poczatkowy wynosi = {0}, a stan aktualny = {1}", StanPoczatkowy, StanAktualny);
        }
        public void zuzyta()
        {
            Console.WriteLine("Zużyto {0} energii", StanAktualny - StanPoczatkowy);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Zadanie 6.1. 
                Napisz program, który tworzy klasę Prostokat, zawierającą dwie prywatne dane 
                składowe: dlugosc, szerokosc, dwie prywatne metody: powierzchnia(), obwod() oraz metodę 
                publiczną – Prezentuj() (która wyświetla powierzchnię i obwód prostokąta) i konstruktor 
                inicjalizujący. W metodzie Main() zdefiniuj obiekt i uruchom dla niego metodę Prezentuj()
             */
            Console.WriteLine("\tZadanie 1\n");
            Prostokat p1 = new Prostokat(2, 3);
            p1.Prezentuj();
            Prostokat p2;
            p2 = new Prostokat(4, 6);
            p2.Prezentuj();

            /*
             * Zadanie 6.2. 
                Uzupełnij program z poprzedniego zadania o definicje tablicy obiektów dla 
                prostokątów. W metodzie Main() wyświetl powierzchnie oraz obwód wszystkich prostokątów 
                w tablicy używając (wewnątrz pętli foreach) metody publicznej Prezentuj(). 
             */
            Console.WriteLine("\n\tZadanie 2\n");
            Prostokat[] tab = new Prostokat[3];
            tab[0] = new Prostokat(2, 6);
            tab[1] = new Prostokat(3, 8);
            tab[2] = new Prostokat(2, 4);
            foreach (Prostokat p in tab)
            {
                p.Prezentuj();
                //p.Wypisz();
            }
            Prostokat.NajwiekszyProstokat(tab);


            /*
             * Zadanie 6.4. 
                Zdefiniuj klasę, która pozwoli na rejestrację zużycia energii elektrycznej. Klasa powinna pozwalać na: 
                 rejestrację początkowego i bieżącego stanu licznika energii,  
                 uzyskanie danych o początkowym oraz bieżącym stanie licznika, 
                 obliczanie zużytej energii.
             */

            Console.WriteLine("\n\tZadanie 4\n");
            Energia licznik = new Energia(4, 98);
            licznik.Wypisz();
            licznik.zuzyta();

            Console.ReadKey();

        }
    }
}
