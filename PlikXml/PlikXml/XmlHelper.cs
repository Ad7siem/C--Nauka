using System.Windows;
using System.Xml.Linq;
using System.Windows.Controls;
using System.Collections.Generic;


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
            XComment comment = new XComment("Window posiotion and title");
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
                window.Title = xml.Root.Element("Window").Attribute("title").Value;

                // odczytanie pozycji i wielkość
                XElement pozycja = xml.Root.Element("Window").Element("posiotion");
                window.Left = double.Parse(pozycja.Element("X").Value);
                window.Top = double.Parse(pozycja.Element("Y").Value);

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
    }

}
