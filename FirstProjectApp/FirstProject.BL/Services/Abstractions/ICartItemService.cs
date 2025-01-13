using FirstProject.BL.DTOs;
using FirstProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.BL.Services.Abstractions
{
    public interface ICartItemService
    {
        Task<ICollection<CartItem>> GetAllAsync();
        Task<CartItem> CreateAsync(CartItemPostDto entityDto);
        Task<CartItem> GetByIdAsync(int id);
        Task<bool> SoftDeleteAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(int id, CartItemPostDto entityDto);
    }
}
