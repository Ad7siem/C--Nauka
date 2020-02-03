using DragAndDrop.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DragAndDrop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Point? positionStarting = null;

        private void ListBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            positionStarting = e.GetPosition(this);

            //ListBox lbSender = sender as ListBox;
            //ListBoxItem movedItem = lbSender.GetItemAt(e.GetPosition(lbSender));
            //if(movedItem != null)
            //{
            //    DataObject dane = new DataObject();
            //    //dane.SetData("Format_Lista", lbSender);
            //    //dane.SetData("Format_ElementyListy", movedItem);
            //    dane.SetData(DataFormats.StringFormat, movedItem.Content as string);
            //    DragDrop.DoDragDrop(lbSender, dane, DragDropEffects.Copy | DragDropEffects.Move);
            //    if (!Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
            //        lbSender.Items.Remove(movedItem);
            //}
        }

        private void ListBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.KeyStates.HasFlag(DragDropKeyStates.ControlKey))
                e.Effects = DragDropEffects.Copy;
            else e.Effects = DragDropEffects.Move;
        }

        private void ListBox_Drop(object sender, DragEventArgs e)
        {
            ListBox lbSender = sender as ListBox;
            /*
            ListBox lbSource = e.Data.GetData("Format_Lista") as ListBox;
            ListBoxItem movedItem = e.Data.GetData("Format_ElementyListy") as ListBoxItem;

            if (!e.KeyStates.HasFlag(DragDropKeyStates.ControlKey))
                lbSource.Items.Remove(movedItem);
            else movedItem = new ListBoxItem() { Content = movedItem.Content };
            */

            //string etivisitMovedItem = e.Data.GetData(DataFormats.StringFormat) as string;
            //ListBoxItem movedItem = new ListBoxItem() { Content = etivisitMovedItem };

            int indeks = lbSender.IndexFromPoint(e.GetPosition(lbSender));
            string[] etivisitMovedItems = (e.Data.GetData(DataFormats.StringFormat) as string).TrimEnd('\n').Split('\n');
            foreach(string etivisitMovedItem in etivisitMovedItems)
            {
                ListBoxItem movedItem = new ListBoxItem() { Content = etivisitMovedItem };
                if (indeks < 0) lbSender.Items.Add(movedItem);
                else lbSender.Items.Insert(indeks++, movedItem);
            }
        }


        private void ListBox_MouseMove(object sender, MouseEventArgs e)
        {
            Point positionCurrent = e.GetPosition(this);
            if (e.LeftButton == MouseButtonState.Released || positionStarting.HasValue)
                return;

            Vector Offset = positionCurrent - positionStarting.Value;
            if (Math.Abs(Offset.X) > SystemParameters.MinimumHorizontalDragDistance || Math.Abs(Offset.Y) > SystemParameters.MinimumVerticalDragDistance)
            {
                ListBox lbSender = sender as ListBox;
                ListBoxItem movedItem = lbSender.SelectedItem as ListBoxItem;
                if(movedItem != null)
                {
                    string etivisitMovedItems = "";
                    foreach (ListBoxItem item in lbSender.SelectedItems)
                        etivisitMovedItems += item.Content as string + "\n";
                    DataObject dane = new DataObject(DataFormats.StringFormat, etivisitMovedItems);

                    //DataObject dane = new DataObject(DataFormats.StringFormat, movedItem.Content as string);
                    DragDrop.DoDragDrop(lbSender, dane, DragDropEffects.Copy | DragDropEffects.Move);
                    positionStarting = null;

                    if (!Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
                        for (int i = lbSender.SelectedItems.Count - 1; i >= 0; i--)
                            lbSender.Items.Remove(lbSender.SelectedItems[i]);
                }
            }
        }
         
    }
}
