using MovieShop.ApplicationCore.Entities;
using MovieShop.ApplicationCore.Model;

namespace MovieShop.ApplicationCore.Contracts.Repository
{
    public interface IMovieRepository:IRepository<Movie>
    {
        //Task<IEnumerable<Movie>> GetMoviesByGenre();
        Task<List<Movie>> GetTop30Movies();
        Task<PagedResultSet<Movie>> GetMoviesByGenres(int genreId, int pageSize = 30, int pageNumber = 1);
        Task<IEnumerable<Movie>> GetMoviesCast();
    }
}
