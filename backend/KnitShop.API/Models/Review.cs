namespace KnitShop.API.Models;                               
                                              
  public class Review                     
  {
      public int Id { get; set; }                              
      public int ProductId { get; set; }
      public int UserId { get; set; }                          
      public int OrderId { get; set; }
      public int Rating { get; set; }         
      public string Comment { get; set; } = string.Empty;
      public DateTime CreatedAt { get; set; } =
  DateTime.UtcNow;                                             
   
      public Product Product { get; set; } = null!;            
      public User User { get; set; } = null!;
      public Order Order { get; set; } = null!;
  }                      