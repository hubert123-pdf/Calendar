using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;

using Kalendarz.WPF;
namespace Kalendarz.Classes
{
    public class APIConnector
    {
        public void getWeather(ref Weather weather,string city)
        {
            using (WebClient web = new WebClient())
            {
                Data data=new Data();
                int index = data.city.IndexOf(city);
                if (index<0)
                {
                    return;
                }
                string id = data.city_id[index].ToString();
                string url = string.Format("https://danepubliczne.imgw.pl/api/data/synop/id/"+id);
                var json = web.DownloadString(url);
             
                
                weather = JsonConvert.DeserializeObject<Weather>(json);
            }
        }
    }
}

