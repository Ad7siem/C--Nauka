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
            for (int i = 0; i < tab.Length; i++)
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
    class Punkt
    {
        public double Punkty_x { get; set; }
        public double Punkty_y { get; set; }
        public Punkt(double x, double y)
        {
            Punkty_x = x;
            Punkty_y = y;
        }
        public void Przesun(double przesun_x, double przesun_y)
        {
            Punkty_x += przesun_x;
            Punkty_y += przesun_y;
        }
        public void Wyswietl()
        {
            Console.WriteLine("{0}, {1}", Punkty_x, Punkty_y);
        }
        public static bool CzyLezy(Punkt[] tab)
        {
            double e1, e2, e3 = 0;
            e1 = Math.Sqrt(Math.Pow(tab[0].Punkty_x - tab[1].Punkty_x, 2) + Math.Pow(tab[0].Punkty_y - tab[1].Punkty_y, 2));
            e2 = Math.Sqrt(Math.Pow(tab[1].Punkty_x - tab[2].Punkty_x, 2) + Math.Pow(tab[1].Punkty_y - tab[2].Punkty_y, 2));
            e3 = Math.Sqrt(Math.Pow(tab[2].Punkty_x - tab[0].Punkty_x, 2) + Math.Pow(tab[2].Punkty_y - tab[0].Punkty_y, 2));
            //if (e1 > e2 && e1 > e3)
            //{
            //    if (e1 == e2 + e3)
            //    {
            //        return true;
            //    }
            //}
            //else if (e2 > e3 && e2 > e1)
            //{
            //    if (e2 == e1 + e3)
            //    {
            //        return true;
            //    }
            //}
            //else if (e3 > e1 && e3 > e2)
            //{
            //    if (e3 == e1 + e2)
            //    {
            //        return true;
            //    }
            //}
            //if ((e1 > e2 && e1 > e3) 
            //    || (e2 > e3 && e2 > e1) 
            //    || (e3 > e1 && e3 > e2))
            //{
            if ((e1 == e2 + e3)
                || (e2 == e1 + e3)
                || (e3 == e1 + e2))
                return true;
            //}
            //sprawdz, ktory jest najdluzszy
            //sprawdz czy najdluzszy jest rowny sumie pozostalych
            return false;
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


            Console.WriteLine("\n\tZadanie 5\n");
            Punkt pk = new Punkt(2.8, 3.6);
            pk.Wyswietl();
            pk.Przesun(3.5, 3.5);
            pk.Wyswietl();

            Console.WriteLine("\n\tZadanie 6\n");
            Punkt[] tab_pk = new Punkt[3];
            tab_pk[0] = new Punkt(2.8, 3.6);
            tab_pk[1] = new Punkt(4.1, 2.9);
            tab_pk[2] = new Punkt(7.7, 5.3);
            foreach (Punkt p in tab_pk)
            {
                p.Wyswietl();
            }

            Console.WriteLine("\n\tZadanie 7 \n");
            tab_pk[0] = new Punkt(0, 0);
            tab_pk[1] = new Punkt(2, 2);
            tab_pk[2] = new Punkt(1, 1);
            Console.WriteLine("{0}", Punkt.CzyLezy(tab_pk));

            Console.ReadKey();

        }
    }
}
