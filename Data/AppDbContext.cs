using Microsoft.EntityFrameworkCore;
using wwe_universe_manager.Interfaces;
using wwe_universe_manager.Models;

namespace wwe_universe_manager.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<WrestlerModel> Wrestler { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            OnBeforeSaving();
            return base.SaveChanges();
        }

        public void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);
            var utcNow = DateTimeOffset.UtcNow;
            foreach (var entry in entries)
            {
                if (entry.Entity is IAuditable entity)
                {
                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedAt = utcNow;
                        entity.LastUpdatedAt = utcNow;
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        entity.LastUpdatedAt = utcNow;
                    }
                }
            }
        }
    }
}
