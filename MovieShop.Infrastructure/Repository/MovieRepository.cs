using Microsoft.EntityFrameworkCore;
using MovieShop.ApplicationCore.Contracts.Repository;
using MovieShop.ApplicationCore.Entities;
using MovieShop.ApplicationCore.Model;
using MovieShop.Infrastructure.Data;

namespace MovieShop.Infrastructure.Repository
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        MovieDbContext movieContext;
        public MovieRepository(MovieDbContext _context) : base(_context)
        {
            movieContext = _context;
        }


        public async Task<IEnumerable<Movie>> GetMoviesCast()
        {
            var movies = await movieContext.Movie.Include(m => m.MovieCasts).ToListAsync();
            return movies;
        }

        public async Task<PagedResultSet<Movie>> GetMoviesByGenres(int genreId, int pageSize=30, int pageNumber=1)
        {
            var totalMovie = await movieContext.MovieGenre.Where(m => m.GenreId == genreId).CountAsync();
            if (totalMovie != 0)
            {
                var movies = await movieContext.MovieGenre.Where(g => g.GenreId == genreId).Include(m => m.Movie)
                    .OrderBy(m=>m.GenreId)
                    .Select(m => new Movie
                    {
                        Id = m.MovieId,
                        PosterUrl = m.Movie.PosterUrl,
                        Title = m.Movie.Title
                    })
                    .Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
                var pagedMovies = new PagedResultSet<Movie>(movies, pageNumber, pageSize, totalMovie);
                return pagedMovies;
            }
           
            throw new Exception("No Movies Found for that genre");

        }
    }
}
