using Microsoft.EntityFrameworkCore;
using MovieShop.ApplicationCore.Contracts.Repository;
using MovieShop.ApplicationCore.Entities;
using MovieShop.Infrastructure.Data;

namespace MovieShop.Infrastructure.Repository
{
    public class CastRepository : BaseRepository<Cast>, ICastRepository
    {
        //MovieDbContext Castdb;
        public CastRepository(MovieDbContext _context) : base(_context)
        {
            //Castdb = _context;
        }

        //public async Task<Cast> GetById(int id)
        //{
        //    var cast = await Castdb.Cast.Where(x => x.Id == id).FirstOrDefaultAsync();
        //    return cast;
        //}
    }
}
