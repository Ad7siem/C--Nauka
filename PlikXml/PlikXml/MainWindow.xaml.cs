using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Xml.Linq;



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
            IEnumerable<XElement> podelementyOkna = xml.Root.Element("okno").Elements();
            s = "Podelementy elementu okno: \n";
            foreach (XElement podelement in podelementyOkna) s += podelement.Name + "\n";
            MessageBox.Show(s);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                //treeView.PopulateTreeViewWithXmlFile(sciezkaPliku);
                XDocument xml = XDocument.Load("htttp://www.nbp.pl/kursy/xml/LastC.xml");
            }
            catch(Exception exc)
            {
                MessageBox.Show("Błąd poczas odczytywania pliku XML: \n" + exc.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
