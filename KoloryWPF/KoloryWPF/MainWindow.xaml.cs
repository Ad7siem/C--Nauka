using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using KoloryWPF.Model;
using KoloryWPF.ModelWidoku;

namespace KoloryWPF
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape) Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            EdycjaKoloru edycjaKoloru = this.Resources["edycjaKoloru"] as EdycjaKoloru;
            edycjaKoloru.Zapisz();
        }
    }
}
