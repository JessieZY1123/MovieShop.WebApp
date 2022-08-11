using MovieShop.ApplicationCore.Model;

namespace MovieShop.ApplicationCore.Contracts.Services
{
    public interface IMovieService
    {
        Task<MovieModel> GetMovieDetailsAsync(int id);
        Task<List<MovieCardModel>> GetTop30Movies();
        Task<IEnumerable<MovieCardModel>> GetMoviesByGenre(int id);
        Task<IEnumerable<MovieCardModel>> GetMoviesCast(int id);
    }
}
