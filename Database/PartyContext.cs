using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
  namespace HackMidwest2018Backend.DatabaseContext
  {
        public class PartyContext : DbContext
        {
            // public DbSet<Blog> Blogs { get; set; }
            // public DbSet<Post> Posts { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite("Data Source=blogging.db");
            }
        }
  }