namespace KnitShop.API.Models;
                                
  public class Product
  {                   
      public int Id { get; set; }
      public int CategoryId { get; set; }
      public string Name { get; set; } = string.Empty;
      public string Description { get; set; } = string.Empty; 
      public decimal Price { get; set; }                     
      public int Stock { get; set; }                          
      public bool IsAvailable { get; set; } = true;
      public DateTime CreatedAt { get; set; } =    
  DateTime.UtcNow;                                            
      public DateTime UpdatedAt { get; set; } =
  DateTime.UtcNow;                                            
                  
      public Category Category { get; set; } = null!;
      public ICollection<ProductImage> Images { get; set; } = 
  new List<ProductImage>();                                  
      public ICollection<OrderItem> OrderItems { get; set; } =
   new List<OrderItem>();
      public ICollection<Review> Reviews { get; set; } = new  
  List<Review>();
  }                                                           
                  
