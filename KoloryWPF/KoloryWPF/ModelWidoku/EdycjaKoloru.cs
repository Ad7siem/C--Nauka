using System.Windows.Media;
using System.Windows.Input;

namespace KoloryWPF.ModelWidoku
{
    using Model;
    using System.ComponentModel;

    public abstract class ObservedObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void onPropertyChanged(params string[] nazwyWlanosci)
        {
            if(PropertyChanged != null)
            {
                foreach (string nazwaWlasnosci in nazwyWlanosci)
                    PropertyChanged(this, new PropertyChangedEventArgs(nazwaWlasnosci));
            }
        }
    }

    public class EdycjaKoloru : ObservedObject
    {
        private readonly Kolor kolor = Ustawienia.Czytaj();

        public byte R
        {
            get
            {
                return kolor.R;
            }
            set
            {
                kolor.R = value;
                onPropertyChanged(nameof(R), nameof(Color));
            }
        }
        public byte G
        {
            get
            {
                return kolor.G;
            }
            set
            {
                kolor.G = value;
                onPropertyChanged(nameof(G), nameof(Color));
            }
        }
        public byte B
        {
            get
            {
                return kolor.B;
            }
            set
            {
                kolor.B = value;
                onPropertyChanged(nameof(B), nameof(Color));
            }
        }

        public Color Color
        {
            get
            {
                return kolor.ToColor();
            }
        }

        private ICommand zapiszCommand;
        public ICommand Zapisz
        {
            get
            {
                if (zapiszCommand == null)
                    zapiszCommand = new RelayCommand(argument => { Ustawienia.Zapisz(kolor); });
                return zapiszCommand;
            }
        }

        private ICommand resetujCommand;
        public ICommand Resetuj
        {
            get
            {
                if(resetujCommand == null)
                {
                    resetujCommand = new RelayCommand(
                        argument =>
                        {
                            R = 0;
                            G = 0;
                            B = 0;
                        },
                        argument => (R != 0) || (G != 0) || (B != 0)
                        );
                }
                return resetujCommand;
            }
        }
    }

    //public class EdycjaKoloru2 : ObservedObject
    //{
    //    public EdycjaKoloru2()
    //    {
    //        Kolor kolor = Ustawienia.Czytaj();
    //        R = kolor.R;
    //        G = kolor.G;
    //        B = kolor.B;
    //    }

    //    private byte r, g, b;

    //    public byte R { get { return r; } set { r = value; onPropertyChanged(nameof(R), nameof(Color)); } }
    //    public byte G { get { return g; } set { r = value; onPropertyChanged(nameof(G), nameof(Color)); } }
    //    public byte B { get { return b; } set { r = value; onPropertyChanged(nameof(B), nameof(Color)); } }

    //    public Color Color
    //    {
    //        get
    //        {
    //            return Color.FromRgb(R, G, B);
    //        }
    //    }

    //    public void Zapisz()
    //    {
    //        Kolor kolor = new Kolor(R, G, B);
    //        Ustawienia.Zapisz(kolor);
    //    }
    //}

    //public class EdycjaKoloru3 : ObservedObject
    //{
    //    private readonly Kolor kolor = Ustawienia.Czytaj();

    //    public Kolor Kolor
    //    {
    //        get
    //        {
    //            return kolor;
    //        }
    //    }

    //    public Color color
    //    {
    //        get
    //        {
    //            return Kolor.ToColor();
    //        }
    //    }
    //    public void Zapisz()
    //    {
    //        Ustawienia.Zapisz(Kolor);
    //    }

    //    //public EdycjaKoloru3()
    //    //{
    //    //    Kolor.PropertyChanged += (object sender, PropertyChangedEventArgs e) =>
    //    //     {
    //    //         onPropertyChanged(nameofColor);
    //    //     };
    //    //}
    //}

    static class Rozszerzenie
    {
        public static Color ToColor(this Kolor kolor)
        {
            return new Color()
            {
                A = 255,
                R = kolor.R,
                G = kolor.G,
                B = kolor.B
            };
        }
    }

    
    
}
