using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Models;
using MyWebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryServiceController : ControllerBase
    {
        public ICategoryRepository ICategoryRepository { get; set; }
        public CategoryServiceController(ICategoryRepository ICategoryRepository)
        {
            this.ICategoryRepository = ICategoryRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(ICategoryRepository.GetAllCategory());
            }
            catch
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var data = ICategoryRepository.GetCategoryById(id);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, CategoryVMDto updateCategory)
        {
            try
            {
                if (id != updateCategory.CategoryCode) return BadRequest();
                ICategoryRepository.UpdateCategory(updateCategory);
                return NoContent();
            }
            catch
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            try
            {
                ICategoryRepository.DeleteCategory(id);
                return Ok();
            }
            catch
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult CreateById(CategoryDto newCategory)
        {
            try
            {
                return Ok(ICategoryRepository.CreateCagory(newCategory));
            }
            catch
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
