using System.Windows;
using System.Windows.Controls;

namespace Przyciski
{
    public class PrzyciskiUMK : Button
    {
        static PrzyciskiUMK()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PrzyciskiUMK), new FrameworkPropertyMetadata(typeof(PrzyciskiUMK)));
        }
    }
}
