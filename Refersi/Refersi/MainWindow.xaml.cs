using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using static Refersi.PlanszaDLaDwochGraczy;

namespace Refersi
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ReversiSilnikAI silnik = new ReversiSilnikAI(1, 8, 8);

        //private SolidColorBrush[] kolory = { Brushes.Ivory, Brushes.Green, Brushes.Sienna };
        string[] nazwyGraczy = { "", "zielony", "brązowy" };

        //private Button[,] plansza;

        //private bool planszaZainicjowana
        //{
        //    get
        //    {
        //        return plansza[silnik.SzerokoscPlanszy - 1, silnik.WysokoscPlanszy - 1] != null;
        //    }
        //}

        private void uzgodnijZawartocPlanszy()
        {
            //if (!planszaZainicjowana) return;

            for (int i = 0; i < silnik.SzerokoscPlanszy; i++)
                for (int j = 0; j < silnik.WysokoscPlanszy; j++)
                {
                    //plansza[i, j].Background = kolory[silnik.PobierzStanPola(i, j)];
                    //plansza[i, j].Content = silnik.PobierzStanPola(i, j).ToString();
                    planszaKontrolka.ZaznaczRuch(new WspolrzednePola(i, j), (StanPola)silnik.PobierzStanPola(i, j));
                }

            przyciskKolorGracza.Background = planszaKontrolka.PedzelDlaStanu((StanPola)silnik.NumerGraczaWykonujacegoNastepnyRuch); //kolory[silnik.NumerGraczaWykonujacegoNastepnyRuch];
            liczbaPolZielonych.Text = silnik.LiczbaPolGracz1.ToString();
            LiczbaPolBrazowych.Text = silnik.LiczbaPolGracz2.ToString();
        }

        //private struct WspolrzednePola
        //{
        //    public int Poziomo, Pionowo;
        //}
        private static string symbolPola(int poziomo, int pionowo)
        {
            if (poziomo > 25 || pionowo > 8) return "(" + poziomo.ToString() + "," + pionowo.ToString() + ")";
            return "" + "ABCDEFGHIJKLMNOPQRSTUVWXYZ"[poziomo] + "123456789"[pionowo];
        }
        //void kliknieciePolaPlanszy(object sender, RoutedEventArgs e)
        private void planszaKontrolka_KliknieciePola(object sender, PlanszaEventArgs e)
        {
            //Button kliknietyPrzycisk = sender as Button;
            //WspolrzednePola wspolrzedne = (WspolrzednePola)kliknietyPrzycisk.Tag;
            int kliknietePoziomo = e.WspolrzednePola.Poziomo; //wspolrzedne.Poziomo;
            int kliknietePionowo = e.WspolrzednePola.Pionowo; //wspolrzedne.Pionowo;

            // wykonywanie ruchu
            int zapamietanyNumerGracza = silnik.NumerGraczaWykonujacegoNastepnyRuch;
            if (silnik.PolozKamien(kliknietePoziomo, kliknietePionowo))
            {
                uzgodnijZawartocPlanszy();

                // lista ruchów
                switch (zapamietanyNumerGracza)
                {
                    case 1:
                        listaRuchowZielony.Items.Add(symbolPola(kliknietePoziomo, kliknietePionowo));
                        break;
                    case 2:
                        listaRuchowBrazowy.Items.Add(symbolPola(kliknietePoziomo, kliknietePionowo));
                        break;
                }
                listaRuchowZielony.SelectedIndex = listaRuchowZielony.Items.Count - 1;
                listaRuchowBrazowy.SelectedIndex = listaRuchowBrazowy.Items.Count - 1;

                // sytuacje specjalne
                ReversiSilnik.SytuacjaNaPlanszy sytuacjaNaPlanszy = silnik.ZbadajSytuacjeNaPlanszy();
                bool koniecGry = false;
                switch (sytuacjaNaPlanszy)
                {
                    case ReversiSilnik.SytuacjaNaPlanszy.BiezacyGraczNieMozeWykonacRuchu:
                        MessageBox.Show("Gracz " + nazwyGraczy[silnik.NumerGraczaWykonujacegoNastepnyRuch] + " zmuszony jest do oddania ruchu");
                        silnik.Pasuj();
                        uzgodnijZawartocPlanszy();
                        break;
                    case ReversiSilnik.SytuacjaNaPlanszy.ObajGraczeNieMogaWykonacRuchu:
                        MessageBox.Show("Obaj gracze nie mogą wykonać ruchu");
                        koniecGry = true;
                        break;
                    case ReversiSilnik.SytuacjaNaPlanszy.WszystkiePolaPlanszySaZajete:
                        koniecGry = true;
                        break;
                }

                // koniec gry -- informacje o wyniku
                if (koniecGry)
                {
                    int numerZwyciezcy = silnik.NumerGraczaMajacegoPrzewage;
                    if (numerZwyciezcy != 0) MessageBox.Show("Wygrał gracz " + nazwyGraczy[numerZwyciezcy], Title, MessageBoxButton.OK, MessageBoxImage.Information);
                    else MessageBox.Show("Remis", Title, MessageBoxButton.OK, MessageBoxImage.Information);
                    if(MessageBox.Show("Czy rozpocząć grę od nowa?", "Reversi", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes)
                    {
                        przygotowaniePlanszyDoNowejGry(1, silnik.SzerokoscPlanszy, silnik.WysokoscPlanszy);
                    }
                    else
                    {
                        planszaKontrolka.IsEnabled = false;
                        przyciskKolorGracza.IsEnabled = false;
                    }
                }
                else
                {
                    if(graPrzeciwkoKomputerowi && silnik.NumerGraczaWykonujacegoNastepnyRuch == 2)
                    {
                        //wykonajNajlepszyRuch();
                        if (timer == null)
                        {
                            timer = new DispatcherTimer();
                            timer.Interval = new System.TimeSpan(0, 0, 0, 0, 300);
                            timer.Tick += (_sender, _e) => { timer.IsEnabled = false; wykonajNajlepszyRuch(); };
                        }
                        timer.Start();
                    }
                }
            }
        }

        private void przygotowaniePlanszyDoNowejGry(int numerGraczaRozpoczynajacego, int szerokoscPlanszy = 8, int wysokoscPlanszy = 8)
        {
            silnik = new ReversiSilnikAI(numerGraczaRozpoczynajacego, szerokoscPlanszy, wysokoscPlanszy);
            listaRuchowZielony.Items.Clear();
            listaRuchowBrazowy.Items.Clear();
            uzgodnijZawartocPlanszy();
            planszaKontrolka.IsEnabled = true;
            przyciskKolorGracza.IsEnabled = true;
        }

        private WspolrzednePola? ustalNajlepszyRuch()
        {
            if (!planszaKontrolka.IsEnabled) return null;

            if(silnik.LiczbaPustychPol == 0)
            {
                MessageBox.Show("Nie ma już wolnych pól na planszy", Title, MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }
            try
            {
                int poziomo, pionowo;
                silnik.ProponujNajlepszyRuch(out poziomo, out pionowo);
                return new WspolrzednePola() { Poziomo = poziomo, Pionowo = pionowo };
            }
            catch
            {
                MessageBox.Show("Bieżący gracz nie może wykonać ruchu", Title, MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }
        }

        private void zaznaczNajlepszyRuch()
        {
            WspolrzednePola? wspolrzednePola = ustalNajlepszyRuch();
            if (wspolrzednePola.HasValue)
            {
                planszaKontrolka.ZaznaczPodpowiedz(wspolrzednePola.Value, (StanPola)silnik.NumerGraczaWykonujacegoNastepnyRuch);
                //SolidColorBrush kolorPodpowiedzi = kolory[silnik.NumerGraczaWykonujacegoNastepnyRuch].Lerp(kolory[0], 0.5f);
                //plansza[wspolrzednePola.Value.Poziomo, wspolrzednePola.Value.Pionowo].Background = kolorPodpowiedzi;
            }
        }

        private void wykonajNajlepszyRuch()
        {
            WspolrzednePola? wspolrzednePola = ustalNajlepszyRuch();
            if (wspolrzednePola.HasValue)
            {
                planszaKontrolka_KliknieciePola(planszaKontrolka, new PlanszaEventArgs() { WspolrzednePola = wspolrzednePola.Value });
                //Button przycisk = plansza[wspolrzednePola.Value.Poziomo, wspolrzednePola.Value.Pionowo];
                //kliknieciePolaPlanszy(przycisk, null);
            }
        }

        private bool graPrzeciwkoKomputerowi = true;

        private DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();

            //// podział siatki na wiersze i kolumny
            //for (int i = 0; i < silnik.SzerokoscPlanszy; i++)
            //    planszaSiatka.ColumnDefinitions.Add(new ColumnDefinition());
            //for (int j = 0; j < silnik.WysokoscPlanszy; j++)
            //    planszaSiatka.RowDefinitions.Add(new RowDefinition());

            //// tworzenie przycisków
            //plansza = new Button[silnik.SzerokoscPlanszy, silnik.WysokoscPlanszy];
            //for (int i = 0; i < silnik.SzerokoscPlanszy; i++)
            //    for(int j = 0; j < silnik.WysokoscPlanszy; j++)
            //    {
            //        Button przycisk = new Button();
            //        przycisk.Margin = new Thickness(0);
            //        planszaSiatka.Children.Add(przycisk);
            //        Grid.SetColumn(przycisk, i);
            //        Grid.SetRow(przycisk, j);
            //        przycisk.Tag = new WspolrzednePola { Poziomo = i, Pionowo = j };
            //        przycisk.Click += new RoutedEventHandler(kliknieciePolaPlanszy);
            //        plansza[i, j] = przycisk;
            //    }

            uzgodnijZawartocPlanszy();

            // testy
            //silnik.PolozKamien(2, 4);
            //silnik.PolozKamien(4, 5);
            //uzgodnijZawartocPlanszy();
        }


        private void przyciskKolorGracza_Click(object sender, RoutedEventArgs e)
        {
            if (Keyboard.Modifiers.HasFlag(ModifierKeys.Control)) wykonajNajlepszyRuch();
            else zaznaczNajlepszyRuch();
        }
        #region Metody zdarzeniowe menu głównego
        //Gra, Nowa gra dla jednego gracza, Rozpoczyna komputer (brązowy)
        private void MenuItem_NowaGraDlaGracza_RozpoczynaKomputer_Click(object sender, RoutedEventArgs e)
        {
            graPrzeciwkoKomputerowi = true;
            Title = "Reversi - 1 gracz";
            przygotowaniePlanszyDoNowejGry(2);
            wykonajNajlepszyRuch(); // oddanie pierwszego ruchu komputerowi
        }
        //Gra, Nowa gra dla jednego gracza, Rozpoczynasz Ty (zielony)
        private void MenuItem_NowaGraDlaGracza_Click(object sender, RoutedEventArgs e)
        {
            graPrzeciwkoKomputerowi = true;
            Title = "Reversi - 1 gracz";
            przygotowaniePlanszyDoNowejGry(1);
        }
        //Gra, Nowa gra dla dwóch graczy
        private void MenuItem_NowaGraDla2Graczy_Click(object sender, RoutedEventArgs e)
        {
            Title = "Reversi - 2 graczy";
            graPrzeciwkoKomputerowi = false;
            przygotowaniePlanszyDoNowejGry(1);
        }
        //Gra, Zamknij
        private void MenuItem_Zamknij_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        //Pomoc, Podpowiedź ruchu
        private void MenuItem_PodpowiedzRuchu_Click(object sender, RoutedEventArgs e)
        {
            zaznaczNajlepszyRuch();
        }
        //Pomoc, Ruch wykonany przez komputer
        private void MenuItem_RuchWykonanyPrzezKomputer_Click(object sender, RoutedEventArgs e)
        {
            wykonajNajlepszyRuch();
        }
        private void MeniItem_ZasadyGry_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "W grze Reversi gracze zajmują na przemian pola planszy, przejmując przy tym wszystkie pola przeciwnika znajujące sie między nowo zajętym polem, a innymi polami gracza wykonującego ruch. Celem gry jest zdobycie większej liczby pól niż przeciwnik. \n" +
                "Gracz może zająć jedynie takie pole, które pozwoli mu przejąć przynajmniej jedno pole przeciwnika. Jeżeli takiego pola nie ma, musi oddać ruch.\n" +
                "Gra kończy się w momencie zajęcia wszystkich pól lub gdy żaden z graczy nie może wykonać ruchu. \n", 
                "Reversi - Zasady gry");

        }
        private void MenuItem_StrategiaKomputera_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Komputer kieruje się nastepującymi priorytetami (od najwyższego): \n" +
                "1. Ustawić pionek w rogu.\n" +
                "2. Unikać ustawienia pionka tuż przy rogu. \n" +
                "3. Ustawić pionek przy krawędzi planszy. \n" +
                "4. Unikać ustawienia pionka w wierszu lub kolumnie oddalonej o jedno pole od krawędzi planszy. \n" +
                "5. Wybierać pole, w wyniku którego zdobyta zostanie największa liczba pól przeciwnika. \n", 
                "Reversi - Strategia Komputera");
        }
        //Pomoc, Strona WWW
        private void MenuItem_StronaWWW_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://pl.wikipedia.org/wiki/Reversi", "Reversi - Wikipedia");
        }
        //Pomoc, Informacje O...
        private void MenuItem_Informacje_Click(object sender, RoutedEventArgs e)
        {
            Version wersja = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            MessageBox.Show("Reversi Mobile\nwersja " + wersja.Major.ToString() + "." + wersja.Minor.ToString() + "." + wersja.Build.ToString() + "." + wersja.Revision.ToString() + "\n(c) Jacek Matulewski 2004,2009\n\nNajnowszą wersję można pobrać ze strony \n (brak)", "Reversi - Informacje o programie");
        }
        #endregion


    }
}
