using Microsoft.Extensions.Logging;
using SmartInventory.Application.Dto.Category;
using SmartInventory.Application.Repository.Interface;
using SmartInventory.Application.Service.Interface;
using SmartInventory.Domain.Model;

namespace SmartInventory.Insfrastructure.Service.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _categoryService;
        private readonly ILogger<CategoryService> _logger;
        public CategoryService(IGenericRepository<Category> CategoryService,ILogger<CategoryService> 
            logger)
        {
            _categoryService = CategoryService;
            _logger = logger;
        }
        public async Task<IEnumerable<ResponseCategoryDto>> GetAllAsync()
        {
            var entity = await _categoryService.GetAllAsync();
            return entity.Select(x => new ResponseCategoryDto
            {
                CategoryId = x.CategoryId,
                Name = x.Name
            });
        }
        public async Task<ResponseCategoryDto?> GetByIdAsync(int id)
        {
            var entity = await _categoryService.GetByIdAsync(id);
            if(entity == null)
            throw new KeyNotFoundException($"Category with Id {id} not found!");
            return  new ResponseCategoryDto
            {
                CategoryId = entity.CategoryId,
                Name = entity.Name
            };
        }
        public async Task AddAsync(CreateCategoryDto dto)
        {
            var entity = new Category
            {
                Name = dto.Name
            };
            _logger.LogInformation("Creating Category");
            await _categoryService.AddAsync(entity);
            _logger.LogInformation("Category Created Successfully!");
            await _categoryService.SaveChangesAsync();
        }
        public async Task<UpdateCategoryDto?> GetForEditAsync(int id)
        {
            var res = await _categoryService.GetByIdAsync(id);
            if (res == null)
                throw new KeyNotFoundException($"Category with ID{id} not found!");
            return new UpdateCategoryDto
            {
                Name = res.Name
            };
        }
        public async Task<bool> UpdateAsync(int id, UpdateCategoryDto dto)
        {
            var entity = await _categoryService.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Category with Id {id} not found!");
            entity.Name = dto.Name;
            await _categoryService.UpdateAsync(entity);
            await _categoryService.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _categoryService.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Category with Id{id} not found!");
            await _categoryService.DeleteAsync(id);
            await _categoryService.SaveChangesAsync();
            return true;
        }
    }
}
