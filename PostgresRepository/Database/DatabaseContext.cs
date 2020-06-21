using Microsoft.EntityFrameworkCore;
using PostgresRepository.Models;
namespace PostgresRepository.Database
{
    public class DatabaseContext : DbContext
    {
        private string ConnectionString
        {
            get
            {
                //To be read from IConfiguraiton.
                return "Server=hovergenpostgresql.postgres.database.azure.com;Database=myposts;Port=5432;User Id=pgAdmin@hovergenpostgresql;Password=Passw0rd1;Ssl Mode=Require;";
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
