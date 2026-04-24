  namespace KnitShop.API.DTOs;                                
   
                     
  public class RegisterDto
  {                                                           
      public string FirstName { get; set; } = string.Empty;
      public string LastName { get; set; } = string.Empty;
      public string Email { get; set; } = string.Empty;       
      public string Password { get; set; } = string.Empty;
      public string PhoneNumber { get; set; } = string.Empty; 
  }               
                                                              
  
  public class LoginDto                                       
  {               
      public string Email { get; set; } = string.Empty;
      public string Password { get; set; } = string.Empty;
  }

       
  public class AuthResponseDto
  {                                                           
      public string Token { get; set; } = string.Empty;
      public string RefreshToken { get; set; } = string.Empty;
      public DateTime ExpiresAt { get; set; }
      public UserProfileDto User { get; set; } = null!;       
  }               

  
  public class UserProfileDto
  {                                                           
      public int Id { get; set; }
      public string FirstName { get; set; } = string.Empty;   
      public string LastName { get; set; } = string.Empty;
      public string Email { get; set; } = string.Empty;
      public string PhoneNumber { get; set; } = string.Empty; 
      public string Role { get; set; } = string.Empty;
  }                                                           
                  
                     
  public class UpdateProfileDto
  {                                                           
      public string FirstName { get; set; } = string.Empty;
      public string LastName { get; set; } = string.Empty;
      public string PhoneNumber { get; set; } = string.Empty;
  }                                                           
   
 