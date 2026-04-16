namespace KnitShop.API.Models;                               
                  
  public enum OrderStatus                                      
  {
      Received,                                                
      InPreparation,
      Shipped,
      Delivered                               
  }                                       

  public enum PaymentMethod                                    
  {
      CashOnDelivery,                                          
      Online      
  }

  public enum PaymentStatus                   
  {                                       
      Pending,
      Paid,                                                    
      Cancelled
  }                                                            
                  
  public class Order
  {
      public int Id { get; set; }
      public int UserId { get; set; }
      public OrderStatus Status { get; set; } =
  OrderStatus.Received;                   
      public PaymentMethod PaymentMethod { get; set; }
      public PaymentStatus PaymentStatus { get; set; } =       
  PaymentStatus.Pending;                      
      public decimal DeliveryPrice { get; set; }               
      public decimal TotalPrice { get; set; }
      public string? Note { get; set; }                        
      public DateTime CreatedAt { get; set; } =
  DateTime.UtcNow;                                             
      public DateTime UpdatedAt { get; set; } =
  DateTime.UtcNow;
                                                               
      public User User { get; set; } = null!; 
      public DeliveryAddress DeliveryAddress { get; set; } =   
  null!;          
      public ICollection<OrderItem> OrderItems { get; set; } = 
  new List<OrderItem>();                      
      public Payment? Payment { get; set; }                    
      public ICollection<Review> Reviews { get; set; } = new
  List<Review>();                                              
  }
