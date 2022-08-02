using Microsoft.EntityFrameworkCore;
using MovieShop.ApplicationCore.Contracts.Repository;
using MovieShop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Infrastructure.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        MovieDbContext db;

        public BaseRepository(MovieDbContext _context)
        {
            db = _context;
        }

        public Task<int> Insert(T entity)
        {
            db.Set<T>().Add(entity);
            return db.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(int id)
        {
            var entity = await db.Set<T>().FindAsync(id);
            db.Set<T>().Remove(entity);
            return await db.SaveChangesAsync();
        }
        public Task<int> Update(T entity)
        {
            db.Entry<T>(entity).State = EntityState.Modified;
            return db.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await db.Set<T>().FindAsync(id);
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await db.Set<T>().ToListAsync();
        }

       

       
    }
}
