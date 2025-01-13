using FirstProject.Core.Models.Common;
using FirstProject.DAL.Contexts;
using FirstProject.DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.DAL.Repositories.Implementations
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public WriteRepository(AppDbContext conext)
        {
            _context = conext;
        }

        public DbSet<T> Table => _context.Set<T>(); 


        public async Task CreateAsync(T entity)
        {
           await Table.AddAsync(entity);
           int rows = await _context.SaveChangesAsync();           
        }

        public void Delete(T entity)
        {
            Table.Remove(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            int rows = await _context.SaveChangesAsync();
            return rows;
        }

        public void Update(T entity)
        {
           Table.Update(entity);
        }
    }
}
