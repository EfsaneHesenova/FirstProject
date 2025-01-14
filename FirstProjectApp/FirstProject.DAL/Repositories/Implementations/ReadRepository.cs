using FirstProject.Core.Models.Common;
using FirstProject.DAL.Contexts;
using FirstProject.DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.DAL.Repositories.Implementations
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public ReadRepository(AppDbContext context)
        {
            _context = context;
        }

        public Microsoft.EntityFrameworkCore.DbSet<T> Table => _context.Set<T>();

        public async Task<ICollection<T>> GetAllAsync()
        {
          return await  Table.ToListAsync();

        }

        public IQueryable<T> GetAllByCondition(Expression<Func<T, bool>> condition)
        {
            IQueryable<T> query = Table.AsQueryable();
            query = query.Where(condition);
            return query;

        }

        public async Task<T> GetByIdAsync(int id, bool isTracking, params string[] includes)
        {
            IQueryable<T> query = Table.AsQueryable();
            if(!isTracking)
            {
                query = query.AsNoTracking();
            }
            if(includes.Length > 0)
            {
                foreach(string include in includes)
                {
                    query = query.Include(include);
                }
            }
            T? entity = await query.SingleOrDefaultAsync(x=> x.Id == id);
            return entity;

        }

        public async Task<T> GetOneByCondition(Expression<Func<T, bool>> condition)
        {
            IQueryable<T> query = Table.AsQueryable();
            T? entity = await query.SingleOrDefaultAsync(condition);
            return entity;
        }

        public async Task<bool> IsExist(int id)
        {
           return await Table.AnyAsync(x => x.Id == id);
        }
    }
}
