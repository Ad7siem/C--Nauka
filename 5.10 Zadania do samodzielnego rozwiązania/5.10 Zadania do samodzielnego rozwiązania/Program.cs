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
        static int Czy_Nalezy(int a, int b, int x)
        {
            int wynik = 0;
            if (a < x && b > x)
                return wynik + 1;
            else
                return wynik - 1;
        }
        static void Przesun (double[] A, double[] wek)
        {
            for(int i = 0; i < A.Length; i++)
            {
                A[i] = A[i] + wek[i];
            }
        }
        static int[] MnozenieTablicy (int[] tab, int x)
        {
            int[] wynikowa = {1,4,6,8,2 };
            int a = 0;
            for (int i = 0; i < tab.Length; i++)
            {
                wynikowa[i] = tab[i] * x;
                a++;
            }

            return wynikowa;
        }
        static void MnozenieTablicyV(int[] tab, int x)
        {
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = tab[i] * x;
            }
        }
        static void MnozenieTablicyV(string[] tab, int x)
        {
            for (int i = 0; i < tab.Length; i++)
            {
                string temp = tab[i];
                for (int j = 0; j < x-1; j++)
                {
                    tab[i] = tab[i] + temp;
                }
            }
        }
        static void Rysuj(int x, int y, string z)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Console.Write(z);
                }
                Console.WriteLine();
            }
        }
        static void W_5_7 (int x, int n)
        {
            int W = 0;
            for (int i = 1; i <= n; i++)
            {
                if (i == 1) Console.Write("W = ({0} + {1})", x, i);
                else if (i == n) Console.Write(" + ({0} + {1}) = ", x, i);
                else Console.Write(" + ({0} + {1})", x, i);
                W += (x + i);
            }
            Console.WriteLine(W);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("\tZadanie 5.1\n");
            Console.WriteLine("Proszę podać temperature w stopniach Fahrenheita: ");
            double f = double.Parse(Console.ReadLine());
            Temperatura(f);

            Console.WriteLine("\n\tZadanie 5.2\n");
            Console.WriteLine("Podaj wartości a, b, x");
            Console.Write("a = ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("b = ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("x = ");
            int x = int.Parse(Console.ReadLine());
            if (Czy_Nalezy(a, b, x) > 0)
            {
                Console.WriteLine("Liczba {0} znajduje się w przedziale ({1}, {2})", x, a, b);
            }
            else if (Czy_Nalezy(a, b, x) < 0)
            {
                Console.WriteLine("Liczba {0} NIE znajduje się w przedziale ({1}, {2})", x, a, b);
            }

            Console.WriteLine("\n\tZadanie 5.3\n");
            Console.WriteLine("Podaj współrzędne punktu A: ");
            double[] A = new double[2];
            for(int i = 0; i < A.Length; i++)
            {
                if (i == 0)
                    Console.Write("x = ");
                else if (i == 1)
                    Console.Write("y = ");
                int wspolrzedna = int.Parse(Console.ReadLine());
                A[i] = wspolrzedna;
            }
            double[] wek = { 3, 2 };
            Console.WriteLine("Punkt A ({0}, {1}) + wektor ({2}, {3})", A[0], A[1], wek[0], wek[1]);
            Przesun(A, wek);
            for (int i = 0; i < A.Length; i++)
                Console.WriteLine("x = {0}", A[i]);


            Console.WriteLine("\n\tZadanie 5.4\n");
            int[] tab5_4 = { 1, 4, 6, 8, 2 };
            Console.WriteLine("Podaj wartość mnożnika");
            int mnoznik = int.Parse(Console.ReadLine());
            for (int i = 0; i < tab5_4.Length; i++)
            {
                if(i == 0) Console.Write("({0},",MnozenieTablicy(tab5_4, mnoznik)[i]);
                else if (i == (tab5_4.Length - 1)) Console.WriteLine("{0})", MnozenieTablicy(tab5_4, mnoznik)[i]);
                else Console.Write("{0},", MnozenieTablicy(tab5_4, mnoznik)[i]);
            }
            MnozenieTablicyV(tab5_4, mnoznik);
            for (int i = 0; i < tab5_4.Length; i++)
            {
                if (i == 0) Console.Write("({0},", tab5_4[i]);
                else if (i == (tab5_4.Length - 1)) Console.WriteLine("{0})", tab5_4[i]);
                else Console.Write("{0},", tab5_4[i]);
            }

            Console.WriteLine("\n\tZadanie 5.5\n");
            Console.WriteLine("Podaj długość:");
            int dl = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj szerokość");
            int szer = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj znak");
            string znak = Console.ReadLine();
            Rysuj(dl, szer, znak);

            Console.WriteLine("\n\tZadanie 5.6\n");
            string[] tab5_6 = { "ala", "kot", "dom" };
            Console.WriteLine("Mnożnik brany z zadania 5.4");
            MnozenieTablicyV(tab5_6, mnoznik);
            for (int i = 0; i < tab5_6.Length; i++)
            {
                if (i == 0) Console.Write("({0},", tab5_6[i]);
                else if (i == (tab5_6.Length - 1)) Console.WriteLine("{0})", tab5_6[i]);
                else Console.Write("{0},", tab5_6[i]);
            }

            Console.WriteLine("\n\tZadanie 5.7\n");
            Console.Write("Podaj wartość x: ");
            int x5_7 = int.Parse(Console.ReadLine());
            Console.Write("Podaj wartość n: ");
            int n5_7 = int.Parse(Console.ReadLine());
            W_5_7(x5_7, n5_7);

            Console.WriteLine("\n\tZadanie 5.8\n");

            Console.ReadKey();
        }
    }
}
