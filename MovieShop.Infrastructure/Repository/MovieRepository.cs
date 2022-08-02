using MovieShop.ApplicationCore.Contracts.Repository;
using MovieShop.ApplicationCore.Entities;
using MovieShop.Infrastructure.Data;

namespace MovieShop.Infrastructure.Repository
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieDbContext _context) : base(_context)
        {
        }
    }
}
