using MyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Services
{
    public interface ICategoryRepository
    {
        List<CategoryVMDto> GetAllCategory();
        CategoryVMDto GetCategoryById(int Id);
        CategoryVMDto CreateCagory(CategoryDto newCategory);
        void UpdateCategory(CategoryVMDto updateCategory);
        void DeleteCategory(int Id);
    }
}
