using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using KoloryWPF.Model;
using KoloryWPF.ModelWidoku;

namespace KoloryWPF
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Color KolorProstokata
        {
            get
            {
                return (rectangle.Fill as SolidColorBrush).Color;
            }
            set
            {
                (rectangle.Fill as SolidColorBrush).Color = value;
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            Color kolor = Ustawienia.Czytaj().ToColor();
            rectangle.Fill = new SolidColorBrush(Colors.Black);
            sliderR.Value = kolor.R;
            sliderG.Value = kolor.G;
            sliderB.Value = kolor.B;
        }

        private void sliderRGB_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Color kolor = Color.FromRgb(
                (byte)sliderR.Value,
                (byte)sliderG.Value,
                (byte)sliderB.Value);
            KolorProstokata = kolor;
        }


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape) Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Ustawienia.Zapisz(new Kolor(KolorProstokata.R, KolorProstokata.G, KolorProstokata.B));
        }
    }
}
