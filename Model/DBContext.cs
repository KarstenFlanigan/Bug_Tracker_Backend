using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.IO;

namespace Bug_Tracker_Backend.Model
{
    public class DBContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Developer> Developers { get; set; }

        //add-migration School
        //Update-database
        //update-database -verbose
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        //ADDED FOR EFCORE TO WORK
        public DBContext(DbContextOptions<DBContext> options)
       : base(options)
        {
        }

    }
}

