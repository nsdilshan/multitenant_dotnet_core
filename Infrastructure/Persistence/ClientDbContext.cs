using Core.Contracts;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ClientDbContext : DbContext
    {
        public string ClientId { get; set; }
        private readonly IClientService _clientService;

        public ClientDbContext(DbContextOptions options, IClientService clientService) : base(options)
        {
            _clientService = clientService;
            ClientId = _clientService.GetClient()?.ClientId;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Branch> Branches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasQueryFilter(a => a.ClientId == ClientId);
            modelBuilder.Entity<User>().HasQueryFilter(a => a.ClientId == ClientId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var tenantConnectionString = _clientService.GetConnectionString();
            if (!string.IsNullOrEmpty(tenantConnectionString))
            {
                optionsBuilder.UseSqlServer(_clientService.GetConnectionString());
            }
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<IClient>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                    case EntityState.Modified:
                        entry.Entity.ClientId = ClientId;
                        break;
                }
            }
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}