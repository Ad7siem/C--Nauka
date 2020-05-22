using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace KoloryWPF
{
    public class ZamkniecieOknaPoNacisnieciuKlawisza : Behavior<Window>
    {
        public Key Klawisz { get; set; }

        protected override void OnAttached()
        {
            Window window = this.AssociatedObject;
            if (window != null) window.PreviewKeyDown += Window_PreviewKeyDown;
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Window window = (Window)sender;
            if (e.Key == Klawisz) window.Close();
        }
    }

    public class PrzyciskZamykajacyOkno : Behavior<Window>
    {
        public static readonly DependencyProperty PrzyciskProperty = DependencyProperty.Register(
            "Przycisk",
            typeof(Button),
            typeof(PrzyciskZamykajacyOkno),
            new PropertyMetadata(null, PrzyciskZmieniony)
            );

        public Button Przycisk
        {
            get { return (Button)GetValue(PrzyciskProperty); }
            set { SetValue(PrzyciskProperty, value); }
        }

        public static readonly DependencyProperty PolecenieProperty = DependencyProperty.Register(
            "Polecenie",
            typeof(ICommand),
            typeof(PrzyciskZamykajacyOkno));

        public ICommand Polecenie 
        {
            get { return (ICommand)GetValue(PolecenieProperty); }
            set { SetValue(PolecenieProperty, value); }
        }

        public static readonly DependencyProperty ParametrPoleceniaProperty = DependencyProperty.Register(
            "ParametrPolecenia",
            typeof(object),
            typeof(PrzyciskZamykajacyOkno));

        public object ParamtrPolecenia 
        {
            get { return GetValue(ParametrPoleceniaProperty); }
            set { SetValue(ParametrPoleceniaProperty, value); }
        }

        private static void PrzyciskZmieniony(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Window window = (d as PrzyciskZamykajacyOkno).AssociatedObject;
            RoutedEventHandler button_Click = (object sender, RoutedEventArgs _e) => 
            {
                ICommand polecenie = (d as PrzyciskZamykajacyOkno).Polecenie;
                object parametrPolecenia = (d as PrzyciskZamykajacyOkno).ParamtrPolecenia;
                if (polecenie != null) polecenie.Execute(parametrPolecenia);
                window.Close();
            };
            if (e.OldValue != null) ((Button)e.OldValue).Click -= button_Click;
            if (e.NewValue != null) ((Button)e.NewValue).Click += button_Click;
        }
    }
}
