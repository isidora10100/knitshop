 using Microsoft.EntityFrameworkCore;
  using KnitShop.API.Data;                                                                                                            
  using KnitShop.API.Models;

  namespace KnitShop.API.Repositories;                                                                                                
   
  public class ProductRepository : IProductRepository                                                                                 
  {               
      private readonly AppDbContext _context;

      public ProductRepository(AppDbContext context)
      {
          _context = context;
      }

      public async Task<IEnumerable<Product>> GetAllAsync()
      {
          return await _context.Products                                                                                              
              .Include(p => p.Category)
              .Include(p => p.Images)                                                                                                 
              .Include(p => p.Reviews)
              .ToListAsync();
      }                                                                                                                               
   
      public async Task<Product?> GetByIdAsync(int id)                                                                                
      {           
          return await _context.Products
              .Include(p => p.Category)
              .Include(p => p.Images)
              .Include(p => p.Reviews)
              .FirstOrDefaultAsync(p => p.Id == id);                                                                                  
      }
                                                                                                                                      
      public async Task<Product> CreateAsync(Product product)
      {
          _context.Products.Add(product);
          await _context.SaveChangesAsync();
          return product;
      }                                                                                                                               
   
      public async Task<Product> UpdateAsync(Product product)                                                                         
      {           
          _context.Products.Update(product);
          await _context.SaveChangesAsync();
          return product;
      }

      public async Task DeleteAsync(int id)                                                                                           
      {
          var product = await _context.Products.FindAsync(id);                                                                        
          if (product != null)
          {
              _context.Products.Remove(product);
              await _context.SaveChangesAsync();
          }
      }

      public async Task<bool> ExistsAsync(int id)                                                                                     
      {
          return await _context.Products.AnyAsync(p => p.Id == id);                                                                   
      }           
  }
