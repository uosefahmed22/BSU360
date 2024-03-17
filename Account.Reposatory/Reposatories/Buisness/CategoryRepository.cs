using Account.Apis.Errors;
using Account.Core.Dtos.Business;
using Account.Core.Models.ProjectBusiness;
using Account.Core.Services.Business;
using Account.Reposatory.Data.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Reposatory.Reposatories.Buisness
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BusinessDbContext _context;

        public CategoryRepository(BusinessDbContext context)
        {
            _context = context;
        }
        public async Task<Category> AddCategoryAsync(CategoryDto categoryDto)
        {
            var existingCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Name == categoryDto.Name);

            if (existingCategory != null && existingCategory.Name == categoryDto.Name)
            {
                throw new ArgumentException("Category with the same name already exists.");
            }

            var category = new Category
            {
                Name = categoryDto.Name,
                PictureUrl = categoryDto.PictureUrl
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return category;
        }
        public async Task<ApiResponse> DeleteCategoryAsync(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return new ApiResponse(404, "Category not found");
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return new ApiResponse(200, "Category deleted successfully");
        }
        public async Task<Category> UpdateCategoryAsync(Category entity)
        {
            var existingCategory = await _context.Categories.FindAsync(entity.Id);
            if (existingCategory == null)
            {
                throw new ArgumentException("Category not found");
            }

            existingCategory.Name = entity.Name;
            existingCategory.PictureUrl = entity.PictureUrl;

            var existingCategoryWithName = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id != entity.Id && c.Name == entity.Name);

            if (existingCategoryWithName != null)
            {
                throw new ArgumentException("Category name already exists");
            }

            // Save changes to the database
            await _context.SaveChangesAsync();

            return existingCategory;
        }
        public async Task<List<Category>> GetAllCategoryAsync()
        {
            return await _context.Categories.ToListAsync();
        }
        public async Task<Category> GetCategoryByIdAsync(Guid id)
        {
            return await _context.Categories.FindAsync(id);
        }

    }
}
