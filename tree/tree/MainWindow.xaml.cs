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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace tree
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

        #region Przenoszenie okna

        private bool orMoving = false;
        private Point posiotionStarting;
        private Cursor cursor;

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ButtonState == Mouse.LeftButton)
            {
                orMoving = true;
                cursor = Cursor;
                Cursor = Cursors.Hand;
                posiotionStarting = e.GetPosition(this);
            }
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (orMoving)
            {
                Vector Offset = e.GetPosition(this) - posiotionStarting;
                Left += Offset.X;
                Top += Offset.Y;
            }
        }

        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (orMoving)
            {
                Cursor = cursor;
                orMoving = false;
            }
        }
        #endregion

        #region Zamykanie okna
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape) this.Close();
        }

        bool completedDisappearAnimation = false;

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!completedDisappearAnimation)
            {
                Storyboard storyboardScrapingWindow = this.Resources["storyboardScrapingWindow"] as Storyboard;
                storyboardScrapingWindow.Begin();
                e.Cancel = true;
            }
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            completedDisappearAnimation = true;
            Close();
        }
        #endregion
    }
}
