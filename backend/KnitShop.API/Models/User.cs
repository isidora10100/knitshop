namespace KnitShop.API.Models;


public enum UserRole
{
    Customer,
    Admin
}


public class User
{
    public int Id { get; set;}
    public string FirstName { get; set;} = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public UserRole Role { get; set; } = UserRole.Customer;
    public DateTime CreatedAt {get; set;} = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;


    public ICollection<Order> Orders {get; set; } = new List<Order>();
    public ICollection<Review> Reviews {get; set; } = new List<Review>();
    
}   

