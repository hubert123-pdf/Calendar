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
            InitializeComponent();
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            cisnienie_miasta.Text = "Ciśnienie: ";
            temperatura_miasta.Text = "Temperatura: ";
            wilgotnosc_miasta.Text = "Wilgotność: ";

            string city = Wpisz_miasto.Text;
            APIConnector apiConnector = new APIConnector();
            Weather weather = new Weather();
            apiConnector.getWeather(ref weather, city);

            cisnienie_miasta.Text = cisnienie_miasta.Text + weather.cisnienie.ToString() + "hPa";
            temperatura_miasta.Text = temperatura_miasta.Text + weather.temperatura.ToString() + "°C";
            wilgotnosc_miasta.Text = wilgotnosc_miasta.Text + weather.wilgotnosc_wzgledna.ToString() + "%";
        }
        private void AddToDatabase_Click(object sender, RoutedEventArgs e)
        {
            using Context myContext = new Context();
            Event event1 = new Event();
            try
            {
                event1.Name = dodaj_nazwa.Text;
                event1.Description = dodaj_opis.Text;
                event1.Date = DateTime.Parse(dodaj_data.Text);
                event1.Hour = int.Parse(dodaj_godzina.Text);
                if(event1.Hour>23 || event1.Hour < 0)
                {
                    return;
                    ERROR.Text = "Błędny format";
                }
                myContext.Events.Add(event1);
                myContext.SaveChanges();
                ERROR.Text = null;
            }
            catch (Exception ex)
            {
                ERROR.Text = ex.Message.ToString();
            }
            
        }
        private void RemoveFromDatabase_Click(object sender, RoutedEventArgs e)
        {
            using (Context myContext = new Context())
            {
                DateTime date;
                try
                {
                    date = DateTime.Parse(usun_data.Text);
                    var row = myContext.Events.Where(r => r.Date == date).First();
                    myContext.Events.Remove(row);
                    myContext.SaveChanges();
                    ERROR.Text = null;
                }
                catch (Exception ex)
                {
                    ERROR.Text = "Błędny format";
                }
                
            }
        }
        
        private void EditRecord_Click(object sender, RoutedEventArgs e)
        {
            using Context myContext = new Context();
            DateTime date;
            try
            {
                date = DateTime.Parse(edytuj_data.Text);
                var blogs = myContext.Events.Where(r => r.Date == date).First();
                blogs.Name = edytuj_nazwa.Text;
                blogs.Description = edytuj_opis.Text;
                myContext.SaveChanges();
                ERROR.Text = null;

            }
            catch (Exception ex)
            {
                ERROR.Text = "Błędny format";
            }
            
        }
    }
}

