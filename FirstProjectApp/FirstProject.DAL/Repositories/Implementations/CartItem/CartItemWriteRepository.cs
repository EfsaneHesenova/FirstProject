using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstProject.Core.Models;
using FirstProject.DAL.Contexts;
using FirstProject.DAL.Repositories.Abstractions;

namespace FirstProject.DAL.Repositories.Implementations;

public class CartItemWriteRepository : WriteRepository<CartItem>, ICartItemWriteRepository
{
    public CartItemWriteRepository(AppDbContext conext) : base(conext)
    {
    }
}
