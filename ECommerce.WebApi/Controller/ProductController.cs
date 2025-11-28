using ECommerce.Business.Abstract;
using ECommerce.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService =  productService;
            
        }

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody]ProductCreateDto  productCreateDto)
        {
            var result = await _productService.AddAsync(productCreateDto);
            if (result.Status)
                return StatusCode(201,result);
            return NotFound(result);
        }

        [HttpGet("{id:int}/stock")]
        public async Task<IActionResult> UpdateStock(int id, int stock)
        {
            var result = await _productService.UpdateAsync(id, stock);
            if (result.Status) 
                return Ok();
            return BadRequest(result);
        }
        
    }
}
