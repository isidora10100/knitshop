using KnitShop.API.Models;
using Microsoft.EntityFrameworkCore;


namespace KnitShop.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
    {

    }
    public DbSet<User> Users => Set<User>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductImage> ProductImages =>
  Set<ProductImage>();                        
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<DeliveryAddress> DeliveryAddresses =>       
  Set<DeliveryAddress>();                     
    public DbSet<Review> Reviews => Set<Review>();           
    public DbSet<Payment> Payments => Set<Payment>();



}
