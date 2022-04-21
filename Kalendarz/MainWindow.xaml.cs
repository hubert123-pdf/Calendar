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
        public List<Event> Wydarzenia { get; set; }
        public Context myContext = new Context();
        public MainWindow()
        {
            InitializeComponent();
            Zaktualizuj_liste();
        }

        private void Zaktualizuj_liste()
        {
            Wydarzenia = new List<Event>();
            list_view.GetBindingExpression(ListView.ItemsSourceProperty).UpdateTarget();
            {
                foreach (Event e in myContext.Events)
                {
                    Wydarzenia.Add(e);
                }
            }
            DataContext = this;
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
            Event event1 = new Event();
            try
            {
                event1.Name = dodaj_nazwa.Text;
                event1.Description = dodaj_opis.Text;
                event1.Date = dodaj_data.Text;
                event1.Hour = int.Parse(dodaj_godzina.Text);
                if(event1.Hour>23 || event1.Hour < 0)
                {
                    return;
                    ERROR.Text = "Błędny format";
                }
                myContext.Events.Add(event1);
                myContext.SaveChanges();
                InitializeComponent();
                Zaktualizuj_liste();
                ERROR.Text = null;
            }
            catch (Exception ex)
            {
                ERROR.Text = ex.Message.ToString();
            }
            DataContext = this;
        }

        private void RemoveFromDatabase_Click(object sender, RoutedEventArgs e)
        {
            using (Context myContext = new Context())
            {
                string date;
                try
                {
                    date = usun_data.Text;
                    var row = myContext.Events.Where(r => r.Date == date).First();
                    myContext.Events.Remove(row);
                    myContext.SaveChanges();
                    Zaktualizuj_liste();
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
      
            string date;
            try
            {
                date = edytuj_data.Text;
                var blogs = myContext.Events.Where(r => r.Date == date).First();
                blogs.Name = edytuj_nazwa.Text;
                blogs.Description = edytuj_opis.Text;
                myContext.SaveChanges();
                Zaktualizuj_liste();
                ERROR.Text = null;
            }
            catch (Exception ex)
            {
                ERROR.Text = "Błędny format";
            }
        }
    }
}

