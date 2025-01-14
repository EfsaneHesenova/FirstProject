using AutoMapper;
using FirstProject.BL.DTOs.CartItemDtos;
using FirstProject.BL.ExternalServices.Abstractions;
using FirstProject.BL.Services.Abstractions;
using FirstProject.Core.Models;
using FirstProject.DAL.Exceptions;
using FirstProject.DAL.Repositories.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.BL.Services.Implementations
{
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemReadRepository _readRepo;
        private readonly ICartItemWriteRepository _writeRepo;
        private readonly IFileUploadService _fileUploadService;
        private readonly IMapper _mapper;
        IWebHostEnvironment _webHostEnvironment;


        public CartItemService(ICartItemReadRepository readRepo, ICartItemWriteRepository writeRepo, IMapper mapper, IFileUploadService fileUploadService, IWebHostEnvironment webHostEnvironment)
        {
            _readRepo = readRepo;
            _writeRepo = writeRepo;
            _mapper = mapper;
            _fileUploadService = fileUploadService;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<bool> CreateCartItemAsync(CartItemPostDto cartItemPostDto)
        {
            CartItem cartItem = _mapper.Map<CartItem>(cartItemPostDto);
            cartItem.ImgUrl = await _fileUploadService.FileUploadAsync(cartItemPostDto.Image, _webHostEnvironment.ContentRootPath, new[] { ".jpg", ".jpeg", ".png", ".webp" });
            await _writeRepo.CreateAsync(cartItem);

            int rows = await _writeRepo.SaveChangesAsync();
            if (rows == 0)
            {
                throw new Exception("Something went wrong");
            }
            return true;


        }

        public async Task<bool> DeleteCartItemAsync(int id)
        {
            bool isExist = await _readRepo.IsExist(id);
            if (!isExist) { throw new EntityNotFoundException(); }

            CartItem cartItem = await _readRepo.GetByIdAsync(id, false);

            _writeRepo.Delete(cartItem);
            _fileUploadService.DeleteFile(cartItem.ImgUrl, _webHostEnvironment.ContentRootPath);

            int rows = await _writeRepo.SaveChangesAsync();
            if (rows == 0)
            {
                throw new Exception("Something went wrong");
            }
            return true;

        }

        public async Task<ICollection<CartItemGetDto>> GetAllCartItemsAsync()
        {
            ICollection<CartItem> cartItems = await _readRepo.GetAllAsync();
            ICollection<CartItemGetDto> carts = _mapper.Map<ICollection<CartItemGetDto>>(cartItems);
            return carts;
        }

        public ICollection<CartItemGetDto> GetAllCartItemsWhichIsSoftDeleted()
        {
            ICollection<CartItem> cartItems = _readRepo.GetAllByCondition(x => x.IsDeleted).ToList();
            ICollection<CartItemGetDto> carts = _mapper.Map<ICollection<CartItemGetDto>>(cartItems);
            return carts;
        }

        public async Task<CartItemGetDetailDto> GetByIdCartItemAsync(int id)
        {
            bool isExist = await _readRepo.IsExist(id);
            if (!isExist) { throw new EntityNotFoundException(); }
            CartItem cartItems = await _readRepo.GetByIdAsync(id, false);
            CartItemGetDetailDto cart = _mapper.Map<CartItemGetDetailDto>(cartItems);
            return cart;
        }

        public async Task<bool> RestoreCartItemAsync(int id)
        {
            bool isExist = await _readRepo.IsExist(id);
            if (!isExist) { throw new EntityNotFoundException(); }
            CartItem cartItem = await _readRepo.GetOneByCondition(x => x.Id == id && x.IsDeleted);
            cartItem.IsDeleted = false;
            _writeRepo.Update(cartItem);
            int rows = await _writeRepo.SaveChangesAsync();
            if (rows == 0)
            {
                throw new Exception("Something went wrong");
            }
            return true;
        }

        public async Task<bool> SoftDeleteCartItemAsync(int id)
        {
            bool isExist = await _readRepo.IsExist(id);
            if (!isExist) { throw new EntityNotFoundException(); }
            CartItem cartItem = await _readRepo.GetOneByCondition(x => x.Id == id && !x.IsDeleted);
            cartItem.IsDeleted = true;
            _writeRepo.Update(cartItem);
            int rows = await _writeRepo.SaveChangesAsync();
            if (rows == 0)
            {
                throw new Exception("Something went wrong");
            }
            return true;
        }

        public async Task<bool> UpdateCartItemAsync(int id, CartItemPutDto cartItemPutDto)
        {
            bool isExist = await _readRepo.IsExist(id);
            if (!isExist) { throw new EntityNotFoundException(); }
            CartItem cartItem = await _readRepo.GetByIdAsync(id, false);
            _mapper.Map(cartItem, cartItemPutDto);
            _writeRepo.Update(cartItem);


            int rows = await _writeRepo.SaveChangesAsync();
            if (rows == 0)
            {
                throw new Exception("Something went wrong");
            }
            return true;
        }
    }
}
