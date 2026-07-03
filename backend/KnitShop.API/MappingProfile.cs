using AutoMapper;
  using KnitShop.API.DTOs;                                                                                                            
  using KnitShop.API.Models;

  namespace KnitShop.API;

  public class MappingProfile : Profile
  {
      public MappingProfile()
      {                                                                                                                               
          CreateMap<Product, ProductSummaryDto>()
              .ForMember(dest => dest.CategoryName,
                  opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : string.Empty))
              .ForMember(dest => dest.ThumbnailUrl,
                  opt => opt.MapFrom(src => src.Images != null && src.Images.Any() ? src.Images.First().ImageUrl : null))
              .ForMember(dest => dest.AverageRating,
                  opt => opt.MapFrom(src => src.Reviews != null && src.Reviews.Any() ? src.Reviews.Average(r => r.Rating) : 0.0))
              .ForMember(dest => dest.StockQuantity,
                  opt => opt.MapFrom(src => src.Stock));

          CreateMap<Product, ProductDetailDto>()
              .ForMember(dest => dest.CategoryName,
                  opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : string.Empty))
              .ForMember(dest => dest.ImageUrls,
                  opt => opt.MapFrom(src => src.Images != null ? src.Images.Select(i => i.ImageUrl).ToList() : new List<string>()))
              .ForMember(dest => dest.AverageRating,
                  opt => opt.MapFrom(src => src.Reviews != null && src.Reviews.Any() ? src.Reviews.Average(r => r.Rating) : 0.0))
              .ForMember(dest => dest.ReviewCount,
                  opt => opt.MapFrom(src => src.Reviews != null ? src.Reviews.Count : 0))
              .ForMember(dest => dest.StockQuantity,
                  opt => opt.MapFrom(src => src.Stock));

          CreateMap<CreateProductDto, Product>()
              .ForMember(dest => dest.Stock,
                  opt => opt.MapFrom(src => src.StockQuantity));
          CreateMap<UpdateProductDto, Product>()
              .ForMember(dest => dest.Stock,
                  opt => opt.MapFrom(src => src.StockQuantity));

          CreateMap<Category, CategoryDto>()
              .ForMember(dest => dest.ProductCount,
                  opt => opt.MapFrom(src => src.Products != null ? src.Products.Count : 0));

          CreateMap<CreateCategoryDto, Category>();

          CreateMap<User, UserProfileDto>()
              .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));
                                                                                                                                      
          CreateMap<RegisterDto, User>()
              .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())                                                              
              .ForMember(dest => dest.Role, opt => opt.Ignore())
              .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
      }                                                                                                                               
  }
