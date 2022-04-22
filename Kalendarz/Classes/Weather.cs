using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kalendarz.Classes
{
    public class Weather
    {
        public int id_stacji { get; set; }
        public string stacja { get; set; }
        public string data_pomiaru { get; set; }
        public int godzina_pomiaru { get; set; }
        public float temperatura { get; set; }
        public float predkosc_wiatru { get; set; }
        public float kierunek_wiatru { get; set; }
        public float wilgotnosc_wzgledna { get; set; }
        public float suma_opadu { get; set; }
        public float cisnienie { get; set; }
    }
}
