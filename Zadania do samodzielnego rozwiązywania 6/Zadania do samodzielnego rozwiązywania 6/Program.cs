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
    struct ProstokatStruct
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
        public ProstokatStruct(int dl, int sze)
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
        public static void NajwiekszyProstokat(ProstokatStruct[] tab)
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
            double e1, e2, e3;
            e1 = Math.Sqrt(Math.Pow(tab[0].Punkty_x - tab[1].Punkty_x, 2) + Math.Pow(tab[0].Punkty_y - tab[1].Punkty_y, 2));
            e2 = Math.Sqrt(Math.Pow(tab[1].Punkty_x - tab[2].Punkty_x, 2) + Math.Pow(tab[1].Punkty_y - tab[2].Punkty_y, 2));
            e3 = Math.Sqrt(Math.Pow(tab[2].Punkty_x - tab[0].Punkty_x, 2) + Math.Pow(tab[2].Punkty_y - tab[0].Punkty_y, 2));
            /*
            if (e1 > e2 && e1 > e3)
            {
                if (e1 == e2 + e3)
                {
                    return true;
                }
            }
            else if (e2 > e3 && e2 > e1)
            {
                if (e2 == e1 + e3)
                {
                    return true;
                }
            }
            else if (e3 > e1 && e3 > e2)
            {
                if (e3 == e1 + e2)
                {
                    return true;
                }
            }
            if ((e1 > e2 && e1 > e3)
                || (e2 > e3 && e2 > e1)
                || (e3 > e1 && e3 > e2))
            {
            */
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
    class Odcinek
    {
        public Punkt punkt_a { get; set; }
        public Punkt punkt_b { get; set; }
        public Odcinek(Punkt x, Punkt y)
        {
            punkt_a = x;
            punkt_b = y;
        }
        public double DlugoscOdcinka(Punkt a, Punkt b)
        {
            double odcinek;
            odcinek = Math.Sqrt((Math.Pow((a.Punkty_x - b.Punkty_x), 2)) + (Math.Pow((a.Punkty_y - b.Punkty_y), 2)));
            return odcinek;
        }
        public void Wyswietl(Punkt x)
        {
            Console.WriteLine("{0}, {1}", x.Punkty_x, x.Punkty_y);
        }
        public void obliczanie(Punkt a, Punkt b)
        {
            Console.Write("{0} + {1} = ", Math.Pow(a.Punkty_x - b.Punkty_x, 2), Math.Pow(a.Punkty_y - b.Punkty_y, 2));
            Console.WriteLine(Math.Sqrt((Math.Pow(a.Punkty_x - b.Punkty_x, 2)) + (Math.Pow(a.Punkty_y - b.Punkty_y, 2))));
        }
    }
    class Prostopadloscian
    {
        public double szerokosc { get; set; }
        public double dlugosc { get; set; }
        public double wysokosc { get; set; }
        public Prostopadloscian(double a, double b, double h)
        {
            szerokosc = a;
            dlugosc = b;
            wysokosc = h;
        }
        public double Objetosc ()
        {
            double poleProstopadloscianu = 0;
            poleProstopadloscianu = szerokosc * dlugosc * wysokosc;
            return poleProstopadloscianu;
        }
        public void Porownanie(Prostopadloscian[] tab)
        {
            if (tab[0].Objetosc() > tab[1].Objetosc()) Console.WriteLine("Pierwszy prostopadloscian jest wiekszy od drugiego");
            else if (tab[0].Objetosc() < tab[1].Objetosc()) Console.WriteLine("Pierwszy prostopadloscian jest mniejszy od drugiego");
            else Console.WriteLine("Oba prostopadlosciany sa sobie rowne");
            Console.WriteLine("{0}, {1}", tab[0].Objetosc(), tab[1].Objetosc());
        }
        public static bool PorownanieBool(Prostopadloscian[] tab)
        {
            if (tab[0].Objetosc() > tab[1].Objetosc()) 
                return tab[0].Objetosc() > tab[1].Objetosc();
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

            Console.WriteLine("\n\tZadanie 3\n");
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

            /*
             * Zadanie 6.5. 
                Napisz program tworzący klasę Punkt do obsługi punktów na płaszczyźnie. Klasa ta ma 
                zawierać: konstruktor, którego argumentami będą współrzędne punktu, metodę składową 
                Przesun(), realizującą przesunięcie o zadane wielkości oraz metodę składową Wyswietl() 
                wypisującą aktualne współrzędne punktu. Współrzędne punktu mają być zdefiniowane 
                poprzez właściwości. 
             */

            Console.WriteLine("\n\tZadanie 5\n");
            Punkt pk = new Punkt(2.8, 3.6);
            pk.Wyswietl();
            pk.Przesun(3.5, 3.5);
            Console.WriteLine("Punkty zostały przesunięte");
            pk.Wyswietl();

            /*
             * Zadanie 6.6. 
                Napisz program (używając klasy Punkt zdefiniowanej w poprzednim zadaniu), który 
                przechowuje dane o trzech punktach w tablicy obiektów i sprawdza przy pomocy statycznej 
                metody, czy leżą one na jednej prostej.  
             */

            Console.WriteLine("\n\tZadanie 6\n");
            Punkt[] tab_pk = new Punkt[3];
            tab_pk[0] = new Punkt(2.8, 3.6);
            tab_pk[1] = new Punkt(4.1, 2.9);
            tab_pk[2] = new Punkt(7.7, 5.3);
            foreach (Punkt p in tab_pk)
            {
                p.Wyswietl();
            }
            /*
            tab_pk[0] = new Punkt(0, 0);
            tab_pk[1] = new Punkt(2, 2);
            tab_pk[2] = new Punkt(1, 1);
            */
            Console.WriteLine("Czy leżą one na jednej prostej? \n{0}", Punkt.CzyLezy(tab_pk));

            /*
             * Zadanie 6.7. 
                Zdefiniuj klasę Odcinek składającą się z dwóch punktów klasy Punkt. W klasie Odcinek 
                zdefiniuj metodę, która obliczy długość odcinka. 
             */

            Console.WriteLine("\n\tZadanie 7\n");
            Punkt pkt1 = new Punkt(2.4, 3.9);
            Punkt pkt2 = new Punkt(9.7, 4.3);
            Odcinek odk = new Odcinek(pkt1, pkt2);
            odk.Wyswietl(pkt1);
            odk.Wyswietl(pkt2);
            odk.obliczanie(pkt1, pkt2);
            Console.WriteLine("{0}", odk.DlugoscOdcinka(pkt1, pkt2));


            /*
             * Zadanie 6.8. 
                Zdefiniuj klasę Prostopadloscian, która pozwoli na reprezentację danych opisujących 
                długość, szerokość i wysokość prostopadłościanu. W klasie zaimplementuj metody 
                pozwalające na obliczenie objętości prostopadłościanu, oraz porównanie objętości dwóch 
                prostopadłościanów. 
             */

            Console.WriteLine("\n\tZadanie 8\n");
            Prostopadloscian Pro = new Prostopadloscian(3, 5, 7);
            Console.WriteLine("{0}", Pro.Objetosc());
            Prostopadloscian[] tabPro = new Prostopadloscian[2];
            tabPro[0] = new Prostopadloscian(2, 5, 6);
            tabPro[1] = new Prostopadloscian(2, 5, 6);
            tabPro[1].Porownanie(tabPro);
            Console.WriteLine("Czy pierwszy prostopadloscian jest wiekszy od drugieg? \n{0}", Prostopadloscian.PorownanieBool(tabPro));

            /*
             * Zadanie 6.9. 
                Wykonaj zadania 6.1 oraz 6.2 z użyciem struktury (zamiast klasy).
             */

            Console.WriteLine("\tZadanie 9\n");
            ProstokatStruct p1stru = new ProstokatStruct(2, 3);
            p1stru.Prezentuj();
            ProstokatStruct p2Stru;
            p2Stru = new ProstokatStruct(4, 6);
            p2Stru.Prezentuj();
            Console.WriteLine();
            ProstokatStruct[] tabStru = new ProstokatStruct[3];
            tabStru[0] = new ProstokatStruct(2, 6);
            tabStru[1] = new ProstokatStruct(3, 8);
            tabStru[2] = new ProstokatStruct(2, 4);
            foreach (ProstokatStruct p in tabStru)
            {
                p.Prezentuj();
                //p.Wypisz();
            }

            /*
             * Zadanie 6.10. 
                Napisz program z użyciem struktury KandydatNaStudia, która ma posiadać następujące  
                pola: nazwisko, punktyMatematyka, punktyInformatyka, punktyJezykObcy. W trzech ostatnich 
                polach mają być zapisane punkty za przedmioty zdawane na maturze (dla uproszczenia 
                uwzględniamy tylko jeden poziom zdawanej matury, np. podstawowy). Jeden punkt to jeden 
                procent (tj. student, który ma 55% z matematyki ma mieć 55 punktów z tego przedmiotu). 
                Struktura ma posiadać metodę obliczającą łączną liczbę punktów kandydata według 
                przelicznika: 0,6 punktów z matematyki + 0,5 punktów z informatyki + 0,2 punktów z języka 
                obcego. W metodzie Main() utwórz obiekty dla struktury (jako elementy tablicy) dla kilku 
                kandydatów i pokaż listę kandydatów, zawierającą nazwisko i obok, w tej samej linii, 
                obliczoną łączną liczbę punktów.
             */

            Console.WriteLine("\n\tZadanie 10\n");














            Console.ReadKey();
        }
    }
}
