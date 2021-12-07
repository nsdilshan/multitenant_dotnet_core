using Core.Options;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class SystemDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public SystemDbContext(DbContextOptions<SystemDbContext> options)
            : base(options)
        {

        }

        public SystemDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    ClientId = "client01",
                    ClientName = "Client 01",
                    DbName = "ClientDb",
                    DbServer = "mssql"
                }
                );
        }
    }
}