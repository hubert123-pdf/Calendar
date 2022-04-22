using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Kalendarz.Classes
{
    public class Context : DbContext
    {
      public Context(): base (@"Data Source=LAPTOP-VB6C7BV2; Initial Catalog=Kalendarz; Integrated Security=True")
        {

        }
        public DbSet<Event> Events { get; set; }

    }
}
