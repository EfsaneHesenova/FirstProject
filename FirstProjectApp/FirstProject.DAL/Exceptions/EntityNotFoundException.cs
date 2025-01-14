using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.DAL.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException() : base() { }
    public EntityNotFoundException(string message) : base(message) { }
}
