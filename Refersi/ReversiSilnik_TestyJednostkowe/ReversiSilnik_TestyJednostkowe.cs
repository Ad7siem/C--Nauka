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

        [TestMethod]
        public void TestKonstruktora()
        {
            ReversiSilnik silnik = tworzDomyslnySilnik();

            Assert.AreEqual(szerokoscPlanszy, silnik.SzerokoscPlanszy);
            Assert.AreEqual(wysokoscPlanszy, silnik.WysokoscPlanszy);
            Assert.AreEqual(numerGraczaRozpoczynajacego, silnik.NumerGraczaWykonujacegoNastepnyRuch);
        }

        [TestMethod]
        public void TestLiczbPol()
        {
            ReversiSilnik silnik = tworzDomyslnySilnik();

            int calkowitaLiczbaPol = szerokoscPlanszy * wysokoscPlanszy;
            Assert.AreEqual(calkowitaLiczbaPol - 4, silnik.LiczbaPustychPol);
            Assert.AreEqual(2, silnik.LiczbaPolGracz1);
            Assert.AreEqual(2, silnik.LiczbaPolGracz2);
        }
        
        [TestMethod]
        public void TestPobierzStanPola()
        {
            ReversiSilnik silnik = tworzDomyslnySilnik();

            int stanPola = silnik.PobierzStanPola(0, 0);
            Assert.AreEqual(0, stanPola);

            stanPola = silnik.PobierzStanPola(szerokoscPlanszy - 1, 0);
            Assert.AreEqual(0, stanPola);

            stanPola = silnik.PobierzStanPola(0, wysokoscPlanszy - 1);
            Assert.AreEqual(0, stanPola);

            stanPola = silnik.PobierzStanPola(szerokoscPlanszy - 1, wysokoscPlanszy - 1);
            Assert.AreEqual(0, stanPola);

            stanPola = silnik.PobierzStanPola(szerokoscPlanszy / 2 - 1, wysokoscPlanszy / 2 - 1);
            Assert.AreEqual(1, stanPola);

            stanPola = silnik.PobierzStanPola(szerokoscPlanszy / 2, wysokoscPlanszy / 2);
            Assert.AreEqual(1, stanPola);

            stanPola = silnik.PobierzStanPola(szerokoscPlanszy / 2 - 1, wysokoscPlanszy / 2);
            Assert.AreEqual(2, stanPola);

            stanPola = silnik.PobierzStanPola(szerokoscPlanszy / 2, wysokoscPlanszy / 2 - 1);
            Assert.AreEqual(2, stanPola);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPobierzStanPola_PozaPlansza()
        {
            ReversiSilnik silnik = tworzDomyslnySilnik();
            int stanPola = silnik.PobierzStanPola(-1, -1);
        }

        [TestMethod]
        public void TestPolozKamien()
        {
            ReversiSilnik silnik = tworzDomyslnySilnik();

            // przed ruchem
            int poziomo = 1; int pionowo = 3;
            Assert.AreEqual(0, silnik.PobierzStanPola(poziomo, pionowo));
            Assert.AreEqual(0, silnik.PobierzStanPola(poziomo - 1, pionowo));

            // poprawny ruch gracza 1
            bool wynik = silnik.PolozKamien(poziomo, pionowo);
            Assert.IsFalse(wynik);
            Assert.AreEqual(0, silnik.PobierzStanPola(poziomo, pionowo));
            Assert.AreEqual(0, silnik.PobierzStanPola(poziomo - 1, pionowo));

            int calkowitaLiczbaPol = szerokoscPlanszy * wysokoscPlanszy;
            Assert.AreEqual(calkowitaLiczbaPol - 4, silnik.LiczbaPustychPol);
            Assert.AreEqual(2, silnik.LiczbaPolGracz1);
            Assert.AreEqual(2, silnik.LiczbaPolGracz2);

            // niepoprawny ruch gracza 2
            wynik = silnik.PolozKamien(poziomo, pionowo);
            Assert.IsFalse(wynik);

            Assert.AreEqual(calkowitaLiczbaPol - 4, silnik.LiczbaPustychPol);
            Assert.AreEqual(2, silnik.LiczbaPolGracz1);
            Assert.AreEqual(2, silnik.LiczbaPolGracz2);

            // poprawny ruch gracza 2
            wynik = silnik.PolozKamien(poziomo, pionowo + 1);
            Assert.IsFalse(wynik);
            Assert.AreEqual(0, silnik.PobierzStanPola(poziomo, pionowo + 1));
            Assert.AreEqual(0, silnik.PobierzStanPola(poziomo - 1, pionowo + 1));

            Assert.AreEqual(calkowitaLiczbaPol - 4, silnik.LiczbaPustychPol);
            Assert.AreEqual(2, silnik.LiczbaPolGracz1);
            Assert.AreEqual(2, silnik.LiczbaPolGracz2);
        }

    }
}
