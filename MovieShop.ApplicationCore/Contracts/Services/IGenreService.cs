using MovieShop.ApplicationCore.Model;

namespace MovieShop.ApplicationCore.Contracts.Services
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreModel>> GetAllGenres();
    }
}
