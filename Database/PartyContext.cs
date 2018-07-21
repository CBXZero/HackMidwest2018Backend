using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using HackMidwest2018Backend.DatabaseModels;

  namespace HackMidwest2018Backend.DatabaseContext
  {
        public class PartyContext : DbContext
        {
            public DbSet<Event> Events { get; set; }
            public DbSet<Contact> Contacts { get; set; }
            public DbSet<Schedule> Schedules {get; set;}

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite("Data Source=partyPlanner.db");
            }
        }
  }