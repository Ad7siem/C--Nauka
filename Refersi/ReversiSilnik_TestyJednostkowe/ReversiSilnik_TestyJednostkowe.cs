using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refersi;

namespace ReversiSilnik_TestyJednostkowe
{
    [TestClass]
    public class ReversiSilnik_TestyJednostkowe
    {
        const int szerokoscPlanszy = 8;
        const int wysokoscPlanszy = 8;
        const int numerGraczaRozpoczynajacego = 1;

        private ReversiSilnik tworzDomyslnySilnik()
        {
            return new ReversiSilnik(numerGraczaRozpoczynajacego, szerokoscPlanszy, wysokoscPlanszy);
        }

    }
}
