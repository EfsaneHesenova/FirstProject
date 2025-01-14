using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstProject.Core.Models;
using FirstProject.DAL.Repositories.Implementations;

namespace FirstProject.DAL.Repositories.Abstractions;

public interface ICartItemWriteRepository : IWriteRepository<CartItem>
{
}
