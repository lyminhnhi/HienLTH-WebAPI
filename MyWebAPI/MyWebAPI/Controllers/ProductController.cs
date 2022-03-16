using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public static List<ProductDto> Products = new List<ProductDto>();

        [HttpGet]
        public IActionResult GetAllProduct()
        {
            return Ok(Products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(string id)
        {
            try
            {
                var product = Products.FirstOrDefault(p => p.ProductCode == Guid.Parse(id));
                if (product == null) return NotFound();
                return Ok(product);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult CreatenewProduct(ProductVMDto newProducts)
        {
            var product = new ProductDto
            {
                ProductCode = Guid.NewGuid(),
                ProductName = newProducts.ProductName,
                ProductPrice = newProducts.ProductPrice
            };

            Products.Add(product);
            return Ok(new
            {
                Success = true,
                Data = product
            });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProductById(string id, ProductVMDto updateProducts)
        {
            try
            {
                var product = Products.FirstOrDefault(p => p.ProductCode == Guid.Parse(id));
                if (product == null) return NotFound();
                if (product.ProductCode.ToString() != id) return BadRequest();

                product.ProductName = updateProducts.ProductName;
                product.ProductPrice = updateProducts.ProductPrice;

                return Ok(product);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveProductById(string id)
        {
            try
            {
                var product = Products.FirstOrDefault(p => p.ProductCode == Guid.Parse(id));
                if (product == null) return NotFound();

                Products.Remove(product);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
