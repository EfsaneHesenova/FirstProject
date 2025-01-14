using AutoMapper;
using FirstProject.BL.DTOs.CartItemDtos;
using FirstProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.BL.Profiles
{
    public class CartItemProfile: Profile
    {
        public CartItemProfile()
        {
            CreateMap<CartItemPostDto, CartItem>().ReverseMap();
            CreateMap<CartItemGetDto, CartItem>().ReverseMap();
            CreateMap<CartItemPutDto, CartItem>().ReverseMap();
            CreateMap<CartItemGetDetailDto, CartItem>().ReverseMap();
        }
    }
}
