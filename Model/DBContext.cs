using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

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
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-J7R2IVQD\SQLEXPRESS;
                                        Database=Bug_Tracker;Trusted_Connection=True;");
        }

        //ADDED FOR EFCORE TO WORK
        public DBContext(DbContextOptions<DBContext> options)
       : base(options)
        {
        }

    }
}

