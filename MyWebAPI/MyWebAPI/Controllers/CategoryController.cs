using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Data;
using MyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly MyDbContext context;

        public CategoryController(MyDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetAllCategory()
        {
            var categoryList = context.Categories.ToList();
            return Ok(categoryList);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            try
            {
                var category = context.Categories.SingleOrDefault(c => c.CategoryCode == id);
                if (category != null) return Ok(category);
                else return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult CreateCategory(CategoryVMDto newCategory)
        {
            try
            {
                var category = new CategoryEntity
                {
                    CategoryName = newCategory.CategoryName
                };
                context.Categories.Add(category);
                context.SaveChanges();
                return Ok(category);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategoryById(int id, CategoryVMDto newCategory)
        {
            try
            {
                var category = context.Categories.SingleOrDefault(c => c.CategoryCode == id);
                if (category != null)
                {
                    category.CategoryName = newCategory.CategoryName;
                    context.SaveChanges();
                    return NoContent();
                }
                else return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
