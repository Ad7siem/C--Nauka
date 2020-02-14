using System;
using System.Drawing;
using System.Windows.Forms;

namespace tree
{
    public class IconInTheTray
    {
        private NotifyIcon notifyIcon;
        private System.Windows.Window window;

        public IconInTheTray(System.Windows.Window window)
        {
            //ikona
            string nameIcon = "choinka.ico";
            string nameApk = Application.ProductName;
            System.Windows.Resources.StreamResourceInfo sri = System.Windows.Application.GetResourceStream(new Uri(@"/" + nameApk + ";component/" + nameIcon, UriKind.RelativeOrAbsolute));
            Icon icon = new Icon(sri.Stream);

            //menu
            ContextMenuStrip menu = createMenu();

            //ikona w zasobniku

            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = icon;
            notifyIcon.Text = "Choinka " + DateTime.Now.Year.ToString();
            notifyIcon.ContextMenuStrip = menu;
            notifyIcon.Visible = true;

            notifyIcon.DoubleClick += (s, e) =>
            {
                int howManyDaysToTheHolidays = (new DateTime(DateTime.Today.Year, 12, 24) - DateTime.Now).Days;
                notifyIcon.BalloonTipTitle = notifyIcon.Text;
                notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon.BalloonTipText = "Do świąt pozostało " + howManyDaysToTheHolidays + " dni";
                notifyIcon.ShowBalloonTip(3000);
            };

            //menu aplikacji
            this.window = window;
            window.MouseRightButtonDown += (s, e) =>
            {
                System.Windows.Point p = window.PointToScreen(e.GetPosition(window));
                menu.Show((int)p.X, (int)p.Y);
            };
        }

        public bool Visible
        {
            get
            {
                return notifyIcon.Visible;
            }
            set
            {
                notifyIcon.Visible = value;
            }
        }

        private ContextMenuStrip createMenu()
        {
            ContextMenuStrip menu = new ContextMenuStrip();

            ToolStripMenuItem hideToolStripMenuItem = new ToolStripMenuItem("Ukryj");
            hideToolStripMenuItem.Click += (s, e) => { window.Hide(); };
            menu.Items.Add(hideToolStripMenuItem);

            ToolStripMenuItem restoreToolStripMenuItem = new ToolStripMenuItem("Przywróć");
            restoreToolStripMenuItem.Click += (s, e) => { window.Show(); };
            menu.Items.Add(restoreToolStripMenuItem);

            ToolStripMenuItem closeToolStripMenuItem = new ToolStripMenuItem("Zamknij");
            closeToolStripMenuItem.Click += (s, e) => { window.Close(); };
            menu.Items.Add(closeToolStripMenuItem);

            menu.Items.Add(new ToolStripSeparator());

            ToolStripMenuItem aboutTheAutorToolStripMenuItem = new ToolStripMenuItem("O...");
            aboutTheAutorToolStripMenuItem.Click += (s, e) =>
            {
                System.Windows.SplashScreen splashScreen = new System.Windows.SplashScreen("SplashScreen.png");
                splashScreen.Show(false, true);
                System.Threading.Thread.Sleep(1000);
                splashScreen.Close(new TimeSpan(0, 0, 1));
            };
            menu.Items.Add(aboutTheAutorToolStripMenuItem);
            return menu;
        }
        public void Remove()
        {
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
            notifyIcon = null;
        }
    }

}

