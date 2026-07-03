 using KnitShop.API;
 using KnitShop.API.Data;
 using Microsoft.EntityFrameworkCore;
 using Serilog;
 using KnitShop.API.Repositories;
 using KnitShop.API.Services;
 using Microsoft.AspNetCore.Authentication.JwtBearer;
 using Microsoft.IdentityModel.Tokens;
 using Microsoft.OpenApi;
 using System.Text;
   
  var builder = WebApplication.CreateBuilder(args);            
                                          
  builder.Host.UseSerilog((context, config) =>
  {                                                            
      config.ReadFrom.Configuration(context.Configuration);
      config.WriteTo.Console();                                
  });             

  builder.Services.AddControllers();          
  builder.Services.AddEndpointsApiExplorer();
  builder.Services.AddSwaggerGen(options =>
  {
      options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
      {
          Name = "Authorization",
          Type = SecuritySchemeType.Http,
          Scheme = "Bearer",
          BearerFormat = "JWT",
          In = ParameterLocation.Header,
          Description = "Unesi samo token, bez reči 'Bearer' ispred (Swagger je sam dodaje)."
      });

      options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
      {
          { new OpenApiSecuritySchemeReference("Bearer", document), new List<string>() }
      });
  });
                                                               
  builder.Services.AddDbContext<AppDbContext>(options =>
      options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
  builder.Services.AddScoped<IProductRepository, ProductRepository>();
  builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
  builder.Services.AddScoped<IUserRepository, UserRepository>();
  builder.Services.AddScoped<ITokenService, TokenService>();
  builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());

  var jwtSettings = builder.Configuration.GetSection("Jwt");
  var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);                                                                                   
                                                                                                                                           
  builder.Services.AddAuthentication(options =>                                                                                            
  {                                                                                                                                        
      options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
      options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
  })                                                                                                                                       
  .AddJwtBearer(options =>
  {                                                                                                                                        
      options.TokenValidationParameters = new TokenValidationParameters
      {
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidateLifetime = true,                                                                                                         
          ValidateIssuerSigningKey = true,
          ValidIssuer = jwtSettings["Issuer"],                                                                                             
          ValidAudience = jwtSettings["Audience"],
          IssuerSigningKey = new SymmetricSecurityKey(key)                                                                                 
      };
  });                                                        
                                          
  var app = builder.Build();
                                                               
  if (app.Environment.IsDevelopment())
  {                                                            
      app.UseSwagger();
      app.UseSwaggerUI();
  }

  app.UseHttpsRedirection();  
  app.UseAuthentication();                                                                                                                 
  app.UseAuthorization();                                                                                                                  
  app.MapControllers();                                
  
                                                               
  app.Run();
