using System.Windows;
using Microsoft.Win32;
using System.IO;

namespace Notatnik
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private bool orTextChanged = false;
        private string pathFile = null;
        public MainWindow()
        {
            InitializeComponent();

            openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Wybierz plik tekstowy";
            openFileDialog.DefaultExt = "txt";
            openFileDialog.Filter = "Pliki tekstowe (*.txt)|*.txt|Pliki XML (*.xml)|*.xml|Pliki źródłowe (*.cs)|*.cs|Wszystkie pliki (*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Zapisz plik tekstowy";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Filter = openFileDialog.Filter;
            saveFileDialog.FilterIndex = 1;
        }

        private void MenuItem_Open_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(pathFile))
            {
                openFileDialog.InitialDirectory = Path.GetDirectoryName(pathFile);
                openFileDialog.FileName = Path.GetFileName(pathFile);
            }
            bool? result = openFileDialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                pathFile = openFileDialog.FileName;
                textBox.Text = File.ReadAllText(pathFile);
                statusBarText.Text = Path.GetDirectoryName(pathFile);
                orTextChanged = false;
            }
        }

        private void MenuItem_SaveAs_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(pathFile))
            {
                saveFileDialog.InitialDirectory = Path.GetDirectoryName(pathFile);
                saveFileDialog.FileName = Path.GetFileName(pathFile);
            }

            bool? result = saveFileDialog.ShowDialog();
            if(result.HasValue && result.Value)
            {
                pathFile = saveFileDialog.FileName;
                File.WriteAllText(pathFile, textBox.Text);
                statusBarText.Text = Path.GetFileName(pathFile);
                orTextChanged = false;
            }
        }

        private void MenuItem_Save_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(pathFile))
            {
                File.WriteAllText(pathFile, textBox.Text);
                orTextChanged = false;
            }
            else
            {
                MenuItem_SaveAs_Click(sender, e);
            }
        }

        private void MenuItem_Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void textBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            orTextChanged = true;
        }

        private void orSaveTextToAFile (object sender, out bool cancel)
        {
            cancel = false;
            if (orTextChanged)
            {
                MessageBoxResult result = MessageBox.Show("Czy zapisać zmiany w edytowanym dokumencie?", this.Title, MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.Cancel);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        MenuItem_Save_Click(sender, null);
                        break;
                    case MessageBoxResult.No: break;
                    case MessageBoxResult.Cancel:
                    default:
                        cancel = true;
                        break;
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool cancel;
            orSaveTextToAFile(sender, out cancel);
            e.Cancel = cancel;
        }

        private void MenuItem_New_Click(object sender, RoutedEventArgs e)
        {
            bool cancel;
            orSaveTextToAFile(sender, out cancel);
            if (!cancel) textBox.Text = "";
        }

        private void MenuItem_Cofnij_Click(object sender, RoutedEventArgs e)
        {
            textBox.Undo();
        }

        private void MenuItem_Powtorz_Click(object sender, RoutedEventArgs e)
        {
            textBox.Redo();
        }

        private void MenuItem_Cut_Click(object sender, RoutedEventArgs e)
        {
            textBox.Cut();
        }

        private void MenuItem_Copy_Click(object sender, RoutedEventArgs e)
        {
            textBox.Copy();
        }

        private void MenuItem_Paste_Click(object sender, RoutedEventArgs e)
        {
            textBox.Paste();
        }

        private void MenuItem_Del_Click(object sender, RoutedEventArgs e)
        {
            textBox.SelectedText = "";
        }

        private void MenuItem_SelectAll_Click(object sender, RoutedEventArgs e)
        {
            textBox.SelectAll();
        }

        private void MenuItem_Time_Click(object sender, RoutedEventArgs e)
        {
            textBox.SelectedText = System.DateTime.Now.ToString();
        }
    }
}
