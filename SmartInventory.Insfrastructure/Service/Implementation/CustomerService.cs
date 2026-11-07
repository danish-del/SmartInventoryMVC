using Microsoft.Identity.Client;
using SmartInventory.Application.Dto.Category;
using SmartInventory.Application.Dto.Customer;
using SmartInventory.Application.Repository.Interface;
using SmartInventory.Application.Service.Interface;
using SmartInventory.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Insfrastructure.Service.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly IGenericRepository<Customer> _customerRepo;
        public CustomerService(IGenericRepository<Customer> CustomerRepo)
        {
            _customerRepo = CustomerRepo;
        }
        public async Task<IEnumerable<ResponseCustomerDto>> GetAllAsync()
        {
            var entity = await _customerRepo.GetAllAsync();
            return entity.Select(x => new ResponseCustomerDto
            {
                CustomerId = x.CustomerId,
                Name = x.Name,
                Email = x.Email,
                Phone = x.Phone,
                IsActive = x.IsActive
            });
        }
        public async Task<ResponseCustomerDto> GetForEditAsyync(int id)
        {
            var entity = await _customerRepo.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Customer with ID {id} not found!");
            return new ResponseCustomerDto
            {
                CustomerId = entity.CustomerId,
                Name = entity.Name,
                Email = entity.Email,
                Phone = entity.Phone,
                IsActive = entity.IsActive
            };
        }
        public async Task AddAsync(CreateCustomerDto dto)
        {
            var cust = new Customer
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                IsActive = dto.IsActive
            };
            await _customerRepo.AddAsync(cust);
            await _customerRepo.SaveChangesAsync();
        }
        public async Task<UpdateCustomerDto> GetForEditAsync(int id)
        {
            var entity = await _customerRepo.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Id with {id} not found!");
            return new UpdateCustomerDto
            {
                CustomerId = entity.CustomerId,
                Name = entity.Name,
                Email = entity.Email,
                Phone = entity.Phone,
                IsActive = entity.IsActive
            };
        }
        public async Task<bool> UpdateAsync(int id, UpdateCustomerDto dto)
        {
            var entity = await _customerRepo.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Customer with ID {id} not found!");
            entity.CustomerId = dto.CustomerId;
            entity.Name = dto.Name;
            entity.Email = dto.Email;
            entity.Phone = dto.Phone;
            entity.IsActive = dto.IsActive;
            await _customerRepo.UpdateAsync(entity);
            await _customerRepo.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _customerRepo.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Customer with ID {id} not found!");
            await _customerRepo.DeleteAsync(id);
            await _customerRepo.SaveChangesAsync();
            return true;
        }
    }
}
