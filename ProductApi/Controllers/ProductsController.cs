using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.DTOs;
using ProductApi.Models;
using ProductApi.Services;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _servicio;

        public ProductsController(IProductService servico)
        {
            _servicio = servico;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_servicio.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _servicio.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create(ProductCreateDto dto)
        {
            var product = new Product {
                Name = dto.Name,
                Price = dto.Price,
                Stock = dto.stock
            };

            _servicio.Create(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }
    }
}
