using SmartInventory.Application.Dto.Product;
using SmartInventory.Application.Repository.Interface;
using SmartInventory.Application.Service.Interface;
using SmartInventory.Domain.Model;

namespace SmartInventory.Insfrastructure.Service.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _productRepo;
        public ProductService(IGenericRepository<Product> ProductRepo)
        {
            _productRepo = ProductRepo;   
        }
        public async Task<IEnumerable<ResponseProductDto>> GetAllAsync()
        {
            var entity = await _productRepo.GetAllAsync();
            return entity.Select(x => new ResponseProductDto
            {
                ProductId = x.ProductId,
                SKU = x.SKU,
                Name = x.Name,
                Price = x.Price,
                StockQuantity = x.StockQuantity,
                CategoryId = x.CategoryId,
                IsActive = x.IsActive
            });
        }
        public async Task<ResponseProductDto> GetByIdAsync(int id)
        {
            var entity = await _productRepo.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Product with ID {id} not found!");
            return new ResponseProductDto
            {
                ProductId = entity.ProductId,
                SKU = entity.SKU,
                Name = entity.Name,
                Price = entity.Price,
                StockQuantity = entity.StockQuantity,
                CategoryId = entity.CategoryId,
                IsActive = entity.IsActive
            };
        }
        public async Task AddAsync(CreateProductDto dto)
        {
            var prod = new Product
            {
                SKU = dto.SKU,
                Name = dto.Name,
                Price = dto.Price,
                StockQuantity = dto.StockQuantity,
                CategoryId = dto.CategoryId,
                IsActive = dto.isActive
            };
             await _productRepo.AddAsync(prod);
             await _productRepo.SaveChangesAsync();
        }
        public async Task<UpdateProductDto> GetEditForAsync(int id)
        {
            var entity = await _productRepo.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Product with ID {id} not found!");
            return new UpdateProductDto
            {
                SKU = entity.SKU,
                Name = entity.Name,
                Price = entity.Price,
                StockQuantity = entity.StockQuantity,
                CategoryId = entity.CategoryId,
                IsActive = entity.IsActive
            };
        }
        public async Task<bool> UpdateAsync(int id, UpdateProductDto dto)
        {
            var entity = await _productRepo.GetByIdAsync(id);

            if (entity == null)
                return false;

            entity.SKU = dto.SKU;
            entity.Name = dto.Name;
            entity.Price = dto.Price;
            entity.StockQuantity = dto.StockQuantity;
            entity.CategoryId = dto.CategoryId;
            entity.IsActive = dto.IsActive;

            await _productRepo.UpdateAsync(entity);
            await _productRepo.SaveChangesAsync();

            return true;
        }
        public async Task<bool> Delete(int id)
        {
            var entity = await _productRepo.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Product with ID {id} not found!");
            await _productRepo.DeleteAsync(id);
            await _productRepo.SaveChangesAsync();
            return true;
        }
    }
}
