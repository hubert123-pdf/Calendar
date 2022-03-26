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
        private void AddToDatabase_Click(object sender, RoutedEventArgs e)
        {
            using Context myContext = new Context();
            Event event1 = new Event();
            event1.Id = int.Parse(id_wydarzenia.Text);
            event1.Name = nazwa_wydarzenia.Text;
            event1.Description = opis_wydarzenia.Text;
            event1.Created = DateTime.Now;
            myContext.Events.Add(event1); 
            myContext.SaveChanges();
        }
        private void RemoveFromDatabase_Click(object sender, RoutedEventArgs e)
        {
            using (Context myContext = new Context())
            {
                int id = int.Parse(id_do_usuniecia.Text);
                var blogs = myContext.Events.Find(id);
                myContext.Events.Remove(blogs);
                myContext.SaveChanges();
            }
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string city = Wpisz_miasto.Text;
            APIConnector apiConnector = new APIConnector();
            Weather weather = new Weather();
            apiConnector.getWeather(ref weather, city);

            id_miasta.Text = weather.id_stacji.ToString();
            temp_miasta.Text = weather.temperatura.ToString();
            wilg_miasta.Text = weather.wilgotnosc_wzgledna.ToString();
        }
        private void EditRecord_Click(object sender, RoutedEventArgs e)
        {
            using Context myContext = new Context();
            int id = int.Parse(id_wydarzenia_Edit.Text);
            var blogs = myContext.Events.Find(id);
            blogs.Name = nazwa_wydarzenia_Edit.Text;
            blogs.Description = opis_wydarzenia_Edit.Text;
            blogs.Created = DateTime.Now;
            myContext.SaveChanges();
        }
    }
}

