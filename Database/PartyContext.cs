using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using HackMidwest2018Backend.DatabaseModels;

namespace HackMidwest2018Backend.DatabaseContext
{
    public class PartyContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=partyPlanner.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(
                                new Contact
                                {
                                    ContactId = 1,
                                    FirstName = "Teddy",
                                    LastName = "Ivarock",
                                    PhoneNumber = "5555555555"
                                }
            );

            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    EventId = 1,
                    Name = "Teddy's house warming",
                    Description = "I'm lonely and need a party",
                    OwnerContactId = 1
                }
            );
        }
    }
}