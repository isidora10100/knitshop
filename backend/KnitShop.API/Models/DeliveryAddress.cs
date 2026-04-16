public class DeliveryAddress                
  {                                                            
      public int Id { get; set; }
      public int OrderId { get; set; }                         
      public string FullName { get; set; } = string.Empty;
      public string PhoneNumber { get; set; } = string.Empty;  
      public string Street { get; set; } = string.Empty;
      public string City { get; set; } = string.Empty;
      public string PostalCode { get; set; } = string.Empty;
      public string Country { get; set; } = "Srbija";
                                                               
      public Order Order { get; set; } = null!;
  }                          