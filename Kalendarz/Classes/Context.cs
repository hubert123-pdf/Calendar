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
      public Context(): base (@"Data Source=DESKTOP-IQFHTQQ; Initial Catalog=Kalendarz; Integrated Security=True")
            {

            }
        public DbSet<Event> Events { get; set; }

    }
}
