namespace KnitShop.API.Models;                               
                                                               
  public class Payment                                         
  {                                                            
      public int Id { get; set; }
      public int OrderId { get; set; }
      public decimal Amount { get; set; }     
      public PaymentMethod Method { get; set; }
      public PaymentStatus Status { get; set; } =
  PaymentStatus.Pending;                                       
      public string? StripePaymentIntentId { get; set; }
      public DateTime? PaidAt { get; set; }                    
                                                               
      public Order Order { get; set; } = null!;
  }                  