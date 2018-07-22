using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using HackMidwest2018Backend.DatabaseModels;
using System;

namespace HackMidwest2018Backend.DatabaseContext
{
    public class PartyContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Contribution> Contributions {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=partyPlanner.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
            .HasOne(p => p.Owner)
            .WithMany(b => b.OwnedEvents)
            .HasForeignKey(p => p.OwnerContactId);

            modelBuilder.Entity<Schedule>()
            .HasOne(p => p.Event)
            .WithMany(b => b.Schedules)
            .HasForeignKey(p => p.EventId);

            modelBuilder.Entity<Contribution>()
            .HasOne(p => p.Event)
            .WithMany(b => b.Contributions)
            .HasForeignKey(p => p.EventId);

            modelBuilder.Entity<Event>()
            .Property(e => e.EventId)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Contact>()
            .Property(e => e.ContactId)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Contact>()
            .HasAlternateKey(p => p.Email)
            .HasName("AltKey_Contact_Email");

            //Seeding database
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    ContactId = 1,
                    FirstName = "Teddy",
                    LastName = "Ivarock",
                    PhoneNumber = "5555555555",
                    Email = "ItsMeATeddy@gmail.com"
                },
                 new Contact
                {
                    ContactId = 2,
                    FirstName = "Charlie L",
                    LastName = "Ivarock",
                    PhoneNumber = "5555555555",
                    Email = "tripleTheCharliTripleTheFun@gmail.com"
                }
            );

            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    EventId = 2,
                    Title = "Teddy's house warming",
                    Description = "I'm lonely and need a party",
                    OwnerContactId = 1,
                },
                new Event
                {
                    EventId = 1,
                    Title = "Charlie Board gaming",
                    Description = "Party!",
                    OwnerContactId = 2
                }
            );

            modelBuilder.Entity<Schedule>().HasData(
                new Schedule
                {
                    ScheduleId = 1,
                    EventId = 1,
                    EventDate = DateTime.Now
                }
            );

             modelBuilder.Entity<Contribution>().HasData(
                new Contribution
                {
                    ContributionId = 1,
                    EventId = 1,
                    Description = "10 pounds of ground beef"
                }
            );
        }
    }
}