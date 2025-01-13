using FirstProject.BL.DTOs;
using FirstProject.BL.Services.Abstractions;
using FirstProject.Core.Models;
using FirstProject.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.BL.Services.Implementations
{
    public class CartItemService : ICartItemService
    {
        private readonly IReadRepository readRepository
        public Task<CartItem> CreateAsync(CartItemPostDto entityDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<CartItem>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CartItem> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, CartItemPostDto entityDto)
        {
            throw new NotImplementedException();
        }
    }
}
