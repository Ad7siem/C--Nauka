using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refersi
{
    class ReversiSilnik
    {
        public int SzerokoscPlanszy { get; private set; }
        public int WysokoscPlanszy { get; private set; }

        private int[,] plansza;
        public int NumerGraczaWykonujacegoNastepnyRuch { get; private set; } = 1;

        private static int numerPrzeciwnika(int numerGracza)
        {
            return (numerGracza == 1) ? 2 : 1;
        }

        private bool czyWspolrzednePolaPrawidlowe(int poziom, int pionowo)
        {
            return poziom >= 0 && poziom < SzerokoscPlanszy && pionowo >= 0 && pionowo < WysokoscPlanszy;
        }

        public int PobierzStanPola(int poziomo, int pionowo)
        {
            if (!czyWspolrzednePolaPrawidlowe(poziomo, pionowo))
                throw new Exception("Nieprawidłowe wspórzędne pola");
            return plansza[poziomo, pionowo];
        }
    }
}
