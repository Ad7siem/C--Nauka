using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Windows.Media;

namespace PlikXml
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (this.ReadWindowPositionAndTitleFromXmlFile(sciezkaPliku))
                tbTytuł.Text = this.Title;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox) Title = (sender as TextBox).Text;
        }

        private const string sciezkaPliku = "Ustawienia.xml";

        private void Window_Closed(object sender, EventArgs e)
        {
            this.SaveWindowPositionAndTitleToXmlFile(sciezkaPliku);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            XDocument xml = XDocument.Load("Ustawienia.xml");

            // wersja XML
            string wersja = xml.Declaration.Version;
            MessageBox.Show("Wersja XML: " + wersja);

            // odczytywanie nazwy głownego elementu
            string nazwaElementuGlownego = xml.Root.Name.LocalName;
            MessageBox.Show("Nazwa elementu głównego: " + nazwaElementuGlownego);

            // kolekcja podelementów ze wszystkich poziomów drzewa
            IEnumerable<XElement> wszystkiePodelementy = xml.Root.Descendants();
            string s = "Wszystkie podelementy: \n";
            foreach (XElement podelement in wszystkiePodelementy) s += podelement.Name + "\n";
            MessageBox.Show(s);

            // kolekcja podelementów elementu okna
            IEnumerable<XElement> podelementyOkna = xml.Root.Element("window").Elements();
            s = "Podelementy elementu okno: \n";
            foreach (XElement podelement in podelementyOkna) s += podelement.Name + "\n";
            MessageBox.Show(s);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                //treeView.PopulateTreeViewWithXmlFile(sciezkaPliku);
                //XDocument xml = XDocument.Load("..\\..\\MainWindow.xaml");
                //XDocument xml = XDocument.Load("http://www.nbp.pl/kursy/xml/LastC.xml");
                treeView.PopulateTreeViewWithXmlFile("http://www.nbp.pl/kursy/xml/LastC.xml");
            }
            catch(Exception exc)
            {
                MessageBox.Show("Błąd poczas odczytywania pliku XML: \n" + exc.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                TabelaKursowWalutNBP tabelaKursowWalutNBP = XmlHelper.PobierzAktualnaTabeleKursowWalutNBP();
                tbKursyWalutNBP.Text = "Tabela kursów walut";
                tbKursyWalutNBP.Text += "\n\nNumer tabeli: " + tabelaKursowWalutNBP.NumerTabeli;
                tbKursyWalutNBP.Text += "\nData notowania: " + tabelaKursowWalutNBP.DataNotowania.ToLongDateString();
                tbKursyWalutNBP.Text += "\nData publikacji: " + tabelaKursowWalutNBP.DataPublikacji.ToLongDateString();
                foreach (KeyValuePair<string, KursyWalutyNBP> pozycja in tabelaKursowWalutNBP.Pozycja)
                {
                    tbKursyWalutNBP.Text += "\n" + pozycja.Value.ToString();
                }

                // wyszukiwanie pojedyńczej waluty sprzedaż
                // Wersja 1 - sprzedaż
                decimal kursSprzedazyEuro = tabelaKursowWalutNBP.Pozycja["EUR"].KursSprzedazy;
                tbKursyWalutNBP.Text += "\n\nWartość sprzedaży Euro: " + kursSprzedazyEuro.ToString() + " zł";
                // Wersja 2 - sprzedaż
                tbKursyWalutNBP.Text += "\nWartość sprzedaży Euro: " + tabelaKursowWalutNBP.Pozycja["EUR"].KursSprzedazy.ToString() + " zł";

                //wyszukiwanie pojedyńczej waluty kupna
                decimal kursKupnaEuro = tabelaKursowWalutNBP.Pozycja["EUR"].KursyKupna;
                tbKursyWalutNBP.Text += "\nWartość kupna Euro: " + kursKupnaEuro.ToString() + " zł";

                // wyszukanie pojedyńczej waluty
                tbKursyWalutNBP.Text += "\n\nWartość Euro: " + tabelaKursowWalutNBP.Pozycja["EUR"].ToString();

            }
            catch (Exception exc)
            {
                tbKursyWalutNBP.Text = "Błąd podczas pobierania kursó walut NBP:\n" + exc.Message;
            }
        }
    }
}
