using Microsoft.EntityFrameworkCore;
using OnlineDeliveryProject.DataAccess.Configurations;
using OnlineDeliveryProject.Domain;
using System;

namespace OnlineDeliveryProject.DataAccess
{
    public class OnlineDeliveryContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>().HasKey(x => new { x.OrderId, x.ProductId });

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new ExceptionLogConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new RestaurantConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new UseCaseLogConfiguration());

            modelBuilder.Entity<Customer>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Category>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<City>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<CustomerUseCase>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<ExceptionLog>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Order>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<OrderProduct>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Restaurant>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Review>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<UseCaseLog>().HasQueryFilter(p => !p.IsDeleted);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Entity entity)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entity.IsActive = true;
                            entity.CreatedAt = DateTime.UtcNow;
                            entity.DeletedAt = null;
                            entity.IsDeleted = false;
                            entity.ModifiedAt = null;
                            break;
                        case EntityState.Modified:
                            entity.ModifiedAt = DateTime.UtcNow;
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=Delivery;Integrated Security=True");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerUseCase> CustomerUseCases { get; set; }
        public DbSet<ExceptionLog> ExceptionLogs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }
    }
}
