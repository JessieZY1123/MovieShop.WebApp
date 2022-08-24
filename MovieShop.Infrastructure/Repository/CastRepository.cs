using Microsoft.EntityFrameworkCore;
using MovieShop.ApplicationCore.Contracts.Repository;
using MovieShop.ApplicationCore.Entities;
using MovieShop.Infrastructure.Data;

namespace MovieShop.Infrastructure.Repository
{
    public class CastRepository : BaseRepository<Cast>, ICastRepository
    {
        private readonly MovieDbContext castContext;
        public CastRepository(MovieDbContext _context) : base(_context)
        {
            castContext = _context;
        }

        public async Task<Cast> GetByIdAsync(int id)
        {
            var cast = await castContext.Cast
                .Include(c => c.MovieCasts)
                .ThenInclude(c => c.Movies)
                .FirstOrDefaultAsync(c => c.Id == id);
            return cast;
        }
    }
}
