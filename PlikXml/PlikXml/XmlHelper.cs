using System.Windows;
using System.Xml.Linq;
using System.Windows.Controls;
using System.Collections.Generic;
using System;
using System.Globalization;
using System.Linq;

namespace PlikXml
{
    public static class XmlHelper
    {
        public static void SaveWindowPositionAndTitleToXmlFile(this Window window, string filePath)
        {
            //XDocument xml = new XDocument(
            //    new XDeclaration("1.0", "utf-8", "yes"),
            //    new XComment("Window position and title"),
            //    new XElement("parameters",
            //        new XElement("window",
            //            new XAttribute("title", window.Title),
            //            new XElement("position",
            //                new XElement("X", window.Left),
            //                new XElement("Y", window.Top)
            //        ),
            //        new XElement("size",
            //            new XElement("width", window.Width),
            //            new XElement("height", window.Height)
            //            )
            //        )
            //    )
            //);

            //xml.Save(filePath);

            // definiowanie obiektów
            XDeclaration declaration = new XDeclaration("1.0", "utf-8", "yes");
            XComment comment = new XComment("Window position and title");
            XElement parameters = new XElement("parameters");
            XElement _window = new XElement("window");
            XAttribute title = new XAttribute("title", window.Title);
            XElement position = new XElement("position");
            XElement X = new XElement("X", window.Left);
            XElement Y = new XElement("Y", window.Top);
            XElement size = new XElement("size");
            XElement width = new XElement("width", window.Width);
            XElement height = new XElement("height", window.Height);

            // budowanie drzewa (od gałęzi)
            position.Add(X);
            position.Add(Y);
            size.Add(width);
            size.Add(height);
            _window.Add(title);
            _window.Add(position);
            _window.Add(size);
            parameters.Add(_window);

            XDocument xml = new XDocument();
            xml.Declaration = declaration;
            xml.Add(comment);
            xml.Add(parameters);

            // zapis do pliku
            xml.Save(filePath);
        }

        public static bool ReadWindowPositionAndTitleFromXmlFile(this Window window, string filePath)
        {
            try
            {
                XDocument xml = XDocument.Load(filePath);

                // odczytanie tytułu okna
                window.Title = xml.Root.Element("window").Attribute("title").Value;

                // odczytanie pozycji i wielkość
                XElement pozycja = xml.Root.Element("window").Element("position");
                window.Left = double.Parse(pozycja.Element("X").Value);
                window.Top = double.Parse(pozycja.Element("Y").Value);

                XElement wielkosc = xml.Root.Element("window").Element("size");
                window.Width = double.Parse(wielkosc.Element("width").Value);
                window.Height = double.Parse(wielkosc.Element("height").Value);

                return true;
            }
            catch
            {
                return false;
            }
        }

        #region TreeView
        private static void AddElementToNode(XElement elementXml, TreeViewItem treeNode, int level)
        {
            level++;

            IEnumerable<XElement> elements = elementXml.Elements();
            foreach (XElement element in elements)
            {
                string description = element.Name.LocalName;
                if (!element.HasElements && !string.IsNullOrEmpty(element.Value))
                    description += $" ({element.Value.Trim(' ', '\n')})";
                TreeViewItem newNode = new TreeViewItem()
                {
                    Header = description,
                    IsExpanded = true                
                };
            treeNode.Items.Add(newNode);
            AddElementToNode(element, newNode, level);
            }
        }

        public static void PopulateTreeViewWithXmlFile(this TreeView treeView, string filePath)
        {
            treeView.Items.Clear();

            XDocument xml = XDocument.Load(filePath);
            TreeViewItem rootNode = new TreeViewItem()
            {
                Header = xml.Root.Name.LocalName,
                IsExpanded = true
            };
            treeView.Items.Add(rootNode);

            treeView.BeginInit();
            AddElementToNode(xml.Root, rootNode, 0);
            treeView.EndInit();
        }
        #endregion

        #region Kursy walut NBP
        private static KursyWalutyNBP parsujPozycjeTabeliKursowWalutNBP(XElement elementPozycja, IFormatProvider formatProvider)
        {
            KursyWalutyNBP pozycja = new KursyWalutyNBP();
            pozycja.NazwaWaluty = elementPozycja.Element("nazwa_waluty").Value;
            pozycja.Przelicznik = double.Parse(elementPozycja.Element("przelicznik").Value, formatProvider);
            pozycja.KodWaluty = elementPozycja.Element("kod_waluty").Value;
            pozycja.KursyKupna = decimal.Parse(elementPozycja.Element("kurs_kupna").Value, formatProvider);
            pozycja.KursSprzedazy = decimal.Parse(elementPozycja.Element("kurs_sprzedazy").Value, formatProvider);
            return pozycja;
        }

        public static TabelaKursowWalutNBP PobierzAktualnaTabeleKursowWalutNBP()
        {
            IFormatProvider formatProvider = new CultureInfo("pl");

            XDocument xml = XDocument.Load("http://www.nbp.pl/kursy/xml/LastC.xml");

            TabelaKursowWalutNBP tabela = new TabelaKursowWalutNBP();
            tabela.NumerTabeli = xml.Root.Element("numer_tabeli").Value;
            tabela.DataNotowania = DateTime.Parse(xml.Root.Element("data_notowania").Value, formatProvider);
            tabela.DataPublikacji = DateTime.Parse(xml.Root.Element("data_publikacji").Value, formatProvider);
            tabela.Pozycja = new Dictionary<string, KursyWalutyNBP>();
            foreach (XElement elementPozycja in xml.Root.Elements("pozycja"))
            {
                KursyWalutyNBP pozycja = parsujPozycjeTabeliKursowWalutNBP(elementPozycja, formatProvider);

                tabela.Pozycja.Add(pozycja.KodWaluty, pozycja);
            }

            return tabela;
        }
        #endregion

        public static void ZapiszLokalnieTabelęKursówWalut(IEnumerable<KursyWalutyNBP> pozycje, string sciezkaPliku)
        {
            XDocument xml = new XDocument(
                new XDeclaration("1.0", "utf-8", "yer"),
                new XElement("KursyWalut",
                    from pozycja in pozycje
                    //orderby pozycja.KodWaluty
                    select new XElement("Pozycja",
                        new XAttribute("Kod", pozycja.KodWaluty),
                        new XElement("Sprzedaż", pozycja.KursSprzedazy),
                        new XElement("Kupno", pozycja.KursyKupna)
                    )
                )
            );
            xml.Save(sciezkaPliku);
        }
    }

    public struct KursyWalutyNBP
    {
        public string NazwaWaluty;
        public string KodWaluty;
        public double Przelicznik;
        public decimal KursyKupna;
        public decimal KursSprzedazy;

        public string ToString(IFormatProvider formatProvider)
        {
            return KodWaluty + " " + KursyKupna.ToString(formatProvider) + "-" + KursSprzedazy.ToString(formatProvider);
        }

        public override string ToString()
        {
            return ToString(new CultureInfo("pl"));
        }
    }

    public struct TabelaKursowWalutNBP
    {
        public string NumerTabeli;
        public DateTime DataNotowania;
        public DateTime DataPublikacji;
        public Dictionary<string, KursyWalutyNBP> Pozycja;
    }




}
