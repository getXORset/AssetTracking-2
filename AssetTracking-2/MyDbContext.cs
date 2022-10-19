using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking_2
{
    //The class MyDBContext gives us an object for connection with the database "assets".
    internal class MyDbContext : DbContext
    {
        public DbSet<Asset> Assets { get; set; }

        string connectionString = "Data Source=DESKTOP-1R160I9; Initial Catalog = assets; Integrated Security = True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //We tell the app to use the connectionstring.
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
