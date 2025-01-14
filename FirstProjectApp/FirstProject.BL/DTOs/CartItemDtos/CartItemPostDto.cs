using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FirstProject.BL.DTOs.CartItemDtos
{
    public class CartItemPostDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
    }
}
