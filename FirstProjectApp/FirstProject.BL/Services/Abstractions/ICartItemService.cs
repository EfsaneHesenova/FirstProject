using FirstProject.BL.DTOs.CartItemDtos;
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
        Task<ICollection<CartItemGetDto>> GetAllCartItemsAsync();
        ICollection<CartItemGetDto> GetAllCartItemsWhichIsSoftDeleted();
        Task<CartItemGetDetailDto> GetByIdCartItemAsync(int id);
        Task<bool> CreateCartItemAsync(CartItemPostDto cartItemPostDto);
        Task<bool> UpdateCartItemAsync(int id, CartItemPutDto cartItemPutDto);
        Task<bool> DeleteCartItemAsync(int id);
        Task<bool> SoftDeleteCartItemAsync(int id);
        Task<bool> RestoreCartItemAsync(int id);
    }
}
