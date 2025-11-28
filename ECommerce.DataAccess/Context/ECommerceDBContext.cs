using System.Configuration;
using ECommerce.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ECommerce.DataAccess.Context;

public class ECommerceDBContext:DbContext
{
    public ECommerceDBContext(DbContextOptions<ECommerceDBContext> options) : base(options)
    {
    }

    public override int SaveChanges()
    {
        presaveChanges();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        presaveChanges();
        return base.SaveChangesAsync(cancellationToken);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }

    private void presaveChanges()
    {
        IEnumerable<EntityEntry<IBaseEntity>> entities = ChangeTracker.Entries<IBaseEntity>();

        foreach (var entity in entities)
        {
            switch (entity.State)
            {
                case EntityState.Added:
                    entity.Entity.Createdate = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entity.Entity.Updatedate = DateTime.Now;
                    break;
            }
        }
    }
    
}