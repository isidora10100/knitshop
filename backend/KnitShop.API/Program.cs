 using KnitShop.API.Data;                                     
 using Microsoft.EntityFrameworkCore;
 using Serilog;                                               
   
  var builder = WebApplication.CreateBuilder(args);            
                                          
  builder.Host.UseSerilog((context, config) =>
  {                                                            
      config.ReadFrom.Configuration(context.Configuration);
      config.WriteTo.Console();                                
  });             

  builder.Services.AddControllers();          
  builder.Services.AddEndpointsApiExplorer();
  builder.Services.AddSwaggerGen();
                                                               
  builder.Services.AddDbContext<AppDbContext>(options =>
      options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));                  
                                          
  var app = builder.Build();
                                                               
  if (app.Environment.IsDevelopment())
  {                                                            
      app.UseSwagger();
      app.UseSwaggerUI();
  }

  app.UseHttpsRedirection();                  
  app.UseAuthorization();                 
  app.MapControllers();
                                                               
  app.Run();
