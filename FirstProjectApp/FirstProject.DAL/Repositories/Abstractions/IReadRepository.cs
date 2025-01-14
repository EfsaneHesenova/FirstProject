using FirstProject.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.DAL.Repositories.Abstractions
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity, new()
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id, bool isTracking, params string[] includes);
        IQueryable<T> GetAllByCondition(Expression<Func<T, bool>> condition);
        Task<T> GetOneByCondition(Expression<Func<T, bool>> condition);
        Task<bool> IsExist(int id);

    }
}
