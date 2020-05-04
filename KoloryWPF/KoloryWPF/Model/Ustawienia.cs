namespace KoloryWPF.Model
{
    public static class Ustawienia
    {
        public static Kolor Czytaj()
        {
            Properties.Settings ustawienia = Properties.Settings.Default;
            return new Kolor(ustawienia.R, ustawienia.G, ustawienia.B);            
        }

        public static void Zapisz(Kolor kolor)
        {
            Properties.Settings ustawienia = Properties.Settings.Default;
            ustawienia.R = kolor.R;
            ustawienia.G = kolor.G;
            ustawienia.B = kolor.B;
            ustawienia.wielkoscOkna = 600;
            ustawienia.szerokoscOkna = 800;
            ustawienia.Save();
        }
    }
}
