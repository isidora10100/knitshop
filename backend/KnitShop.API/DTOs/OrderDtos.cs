namespace KnitShop.API.DTOs;                                
   
  public class OrderSummaryDto                                
  {               
      public int Id { get; set; }
      public DateTime CreatedAt { get; set; }
      public string Status { get; set; } = string.Empty;
      public decimal TotalAmount { get; set; }                
      public int ItemCount { get; set; }
  }                                                           
                  
  public class OrderDetailDto
  {
      public int Id { get; set; }
      public DateTime CreatedAt { get; set; }                 
      public string Status { get; set; } = string.Empty;
      public decimal TotalAmount { get; set; }                
      public List<OrderItemDto> Items { get; set; } = new();
      public DeliveryAddressDto DeliveryAddress { get; set; } 
  = null!;
  }                                                           
                  
  public class OrderItemDto
  {
      public int ProductId { get; set; }                      
      public string ProductName { get; set; } = string.Empty;
      public int Quantity { get; set; }                       
      public decimal UnitPrice { get; set; }
      public decimal Subtotal { get; set; }                   
  }
                                                              
  public class CreateOrderDto
  {
      public List<CreateOrderItemDto> Items { get; set; } =
  new();
      public DeliveryAddressDto DeliveryAddress { get; set; }
  = null!;                                                    
  }
                                                              
  public class CreateOrderItemDto
  {
      public int ProductId { get; set; }
      public int Quantity { get; set; }
  }

  public class DeliveryAddressDto                             
  {
      public string Street { get; set; } = string.Empty;      
      public string City { get; set; } = string.Empty;
      public string PostalCode { get; set; } = string.Empty;
      public string Country { get; set; } = string.Empty;
  }                