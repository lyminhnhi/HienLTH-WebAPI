using MyWebAPI.Data;
using MyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyDbContext context;

        public CategoryRepository(MyDbContext context)
        {
            this.context = context;
        }

        public CategoryVMDto CreateCagory(CategoryDto newCategory)
        {
            var category = new CategoryEntity
            {
                CategoryName = newCategory.CategoryName
            };
            context.Add(category);
            context.SaveChanges();

            return new CategoryVMDto
            {
                CategoryCode = newCategory.CategoryCode,
                CategoryName = category.CategoryName
            };
        }


        public List<CategoryVMDto> GetAllCategory()
        {
            var categories = context.Categories.Select(x => new CategoryVMDto
            {
                CategoryCode = x.CategoryCode,
                CategoryName = x.CategoryName
            }).ToList();

            return categories;
        }

        public CategoryVMDto GetCategoryById(int Id)
        {
            var category = context.Categories.SingleOrDefault(x => x.CategoryCode == Id);
            if (category != null)
            {
                return new CategoryVMDto
                {
                    CategoryCode = category.CategoryCode,
                    CategoryName = category.CategoryName
                };
            };

            return null;
        }

        public void UpdateCategory(CategoryVMDto updateCategory)
        {
            var category = context.Categories.SingleOrDefault(c => c.CategoryCode == updateCategory.CategoryCode);
            category.CategoryName = updateCategory.CategoryName;
            context.SaveChanges();
        }

        public void DeleteCategory(int Id)
        {
            var category = context.Categories.SingleOrDefault(x => x.CategoryCode == Id);
            if (category != null)
            {
                context.Remove(category);
                context.SaveChanges();
            };
        }
    }
}
