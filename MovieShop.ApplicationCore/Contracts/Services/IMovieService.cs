using MovieShop.ApplicationCore.Model;

namespace MovieShop.ApplicationCore.Contracts.Services
{
    public interface IMovieService
    {
        Task<MovieModel> GetMovieDetailsAsync(int id);
    }
}
