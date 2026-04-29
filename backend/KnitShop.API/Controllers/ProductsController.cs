using AutoMapper;
  using Microsoft.AspNetCore.Mvc;                                                                                                     
  using KnitShop.API.DTOs;
  using KnitShop.API.Models;
  using KnitShop.API.Repositories;                                                                                                    
   
  namespace KnitShop.API.Controllers;                                                                                                 
                  
  [ApiController]
  [Route("api/[controller]")]
  public class ProductsController : ControllerBase
  {
      private readonly IProductRepository _repository;
      private readonly IMapper _mapper;                                                                                               
   
      public ProductsController(IProductRepository repository, IMapper mapper)                                                        
      {           
          _repository = repository;
          _mapper = mapper;
      }

                                                                                                                 
      [HttpGet]
      public async Task<ActionResult<IEnumerable<ProductSummaryDto>>> GetAll()                                                        
      {           
          var products = await _repository.GetAllAsync();
          return Ok(_mapper.Map<IEnumerable<ProductSummaryDto>>(products));
      }                                                                                                                               
   
                                                                                                              
      [HttpGet("{id}")]
      public async Task<ActionResult<ProductDetailDto>> GetById(int id)
      {                                                                                                                               
          var product = await _repository.GetByIdAsync(id);
          if (product == null)                                                                                                        
              return NotFound();

          return Ok(_mapper.Map<ProductDetailDto>(product));
      }

                                                                                                                  
      [HttpPost]
      public async Task<ActionResult<ProductDetailDto>> Create(CreateProductDto dto)                                                  
      {           
          var product = _mapper.Map<Product>(dto);
          var created = await _repository.CreateAsync(product);                                                                       
          return CreatedAtAction(nameof(GetById), new { id = created.Id }, _mapper.Map<ProductDetailDto>(created));
      }                                                                                                                               
                  
                                                                                                                
      [HttpPut("{id}")]
      public async Task<ActionResult<ProductDetailDto>> Update(int id, UpdateProductDto dto)                                          
      {           
          if (!await _repository.ExistsAsync(id))
              return NotFound();
                                                                                                                                      
          var product = _mapper.Map<Product>(dto);
          product.Id = id;                                                                                                            
          var updated = await _repository.UpdateAsync(product);
          return Ok(_mapper.Map<ProductDetailDto>(updated));
      }

                                                                                                             
      [HttpDelete("{id}")]
      public async Task<IActionResult> Delete(int id)                                                                                 
      {           
          if (!await _repository.ExistsAsync(id))
              return NotFound();

          await _repository.DeleteAsync(id);
          return NoContent();
      }                                                                                                                               
  }
