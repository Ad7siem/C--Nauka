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

        private void ListBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListBox lbSender = sender as ListBox;
            ListBoxItem movedItem = lbSender.GetItemAt(e.GetPosition(lbSender));
            if(movedItem != null)
            {
                DataObject dane = new DataObject();
                dane.SetData("Format_Lista", lbSender);
                dane.SetData("Format_ElementyListy", movedItem);
                DragDrop.DoDragDrop(lbSender, dane, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        private void ListBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.KeyStates.HasFlag(DragDropKeyStates.ControlKey))
                e.Effects = DragDropEffects.Copy;
            else e.Effects = DragDropEffects.Move;
        }
    }
}
