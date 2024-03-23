using Account.Apis.Errors;
using Account.Core.Dtos.Business;
using Account.Core.Models.ProjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Services.Business
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategoryByIdAsync(Guid id);
        Task<List<Category>> GetAllCategoryAsync();
        Task<ApiResponse> AddCategoryAsync(CategoryDto categoryDto);
        Task<Category> UpdateCategoryAsync(Category entity);
        Task<ApiResponse> DeleteCategoryAsync(Guid id);
    }
}
