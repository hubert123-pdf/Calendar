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
using Newtonsoft.Json;
using Kalendarz.Classes;
using Kalendarz.WPF;

namespace Kalendarz
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            using Context myContext=new Context();
            
            
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string city = Wpisz_miasto.Text;
            APIConnector apiConnector = new APIConnector();
            Weather weather = new Weather();
            apiConnector.getWeather(ref weather,city);

            id_miasta.Text = weather.id_stacji.ToString();
            temp_miasta.Text=weather.temperatura.ToString();
            wilg_miasta.Text=weather.wilgotnosc_wzgledna.ToString();
        }
    }
}
