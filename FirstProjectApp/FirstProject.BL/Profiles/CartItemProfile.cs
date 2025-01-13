using AutoMapper;
using FirstProject.BL.DTOs;
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
        }
    }
}
