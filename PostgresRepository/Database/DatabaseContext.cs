
using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using PostgresRepository.Models;
namespace PostgresRepository.Database
{
    public class DatabaseContext : DbContext
    {
        private const string CON_APP_SETTINGS = "appsettings.json";
        private const string CON_CON_STR = "DefaultConnection";
        internal IConfiguration Configuration { get; set; }
        public DatabaseContext()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile(CON_APP_SETTINGS);
            Configuration = builder.Build();
        }
        private string ConnectionString
        {
            get
            {
                return Configuration.GetConnectionString(CON_CON_STR);
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(ConnectionString);
        public DbSet<AuthorModel> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorModel>().HasKey(b => b.Id);
            modelBuilder.Entity<AuthorModel>().Property(b => b.FullName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<AuthorModel>().HasIndex(b => b.Email).IsUnique();
            modelBuilder.Entity<AuthorModel>().Property(b => b.Email).HasMaxLength(256).IsRequired();
            modelBuilder.Entity<AuthorModel>().Property(b => b.CreatedDate).IsRequired();
        }
    }
}
