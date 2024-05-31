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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;
using System.Media;
using CheckersProject.ViewModel;

namespace CheckersProject.View
{
    /// <summary>
    /// Interaction logic for OptionsView.xaml
    /// </summary>
    public partial class OptionsView : UserControl
    {
        public OptionsView()
        {
            InitializeComponent();
            mySlider.ValueChanged += Slider_ValueChanged;
        }
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Obținem valoarea curentă a sliderului
            double volume = e.NewValue / 100.0; // Normalizează valoarea la intervalul [0, 1]

            // Setăm volumul media player-ului la valoarea sliderului
            ((MainWindow)Application.Current.MainWindow).SetMediaPlayerVolume(volume);
        }

    }
}
