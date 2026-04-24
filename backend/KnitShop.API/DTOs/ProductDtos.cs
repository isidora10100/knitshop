namespace KnitShop.API.DTOs;

public class ProductSummaryDto
{
    public int Id { get; set;}
    public string Name { get; set;} = string.Empty;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string? ThumbnailUrl { get; set; }
    public double AverageRating { get; set; }

}


public class ProductDetailDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;                                                                       
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }                                                                                          
    public string CategoryName { get; set; } = string.Empty;
    public List<string> ImageUrls { get; set; } = new();                                                                            
    public double AverageRating { get; set; }                                                                                       
    public int ReviewCount { get; set; }
    public DateTime CreatedAt { get; set; }
}



public class CreateProductDto
  {                                                                                                                                   
    public string Name { get; set; } = string.Empty;                                                                              
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }                                                                                              
    public int StockQuantity { get; set; }
    public int CategoryId { get; set; }                                                                                             
  }                                                                                                                                 

                                                                                
public class UpdateProductDto
  {                                                                                                                                   
    public string Name { get; set; } = string.Empty;                                                                              
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }                                                                                              
    public int StockQuantity { get; set; }
    public int CategoryId { get; set; }                                                                                             
  }       



