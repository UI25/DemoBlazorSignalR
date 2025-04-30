using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorSignalR.Shared.Models;

namespace BlazorSignalR.Server.Data
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext (DbContextOptions<BooksDbContext> options)
            : base(options)
        {
        }
        public DbSet<Book> Book { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=BookDB;Integrated Security=True;TrustServerCertificate=True;User ID=sa; Password=Sygzalp09102016..; MultipleActiveResultSets=true;");
        }
    }
}
