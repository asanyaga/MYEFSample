using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEFSample
{
    public class MyContext : DbContext
    {
        public MyContext(string connectionString) : base(connectionString)
        {
            
        }

        public DbSet<Country> Countries { get; set; } 
    }
}
