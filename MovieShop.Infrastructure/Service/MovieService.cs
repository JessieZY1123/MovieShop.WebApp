using MovieShop.ApplicationCore.Contracts.Repository;
using MovieShop.ApplicationCore.Contracts.Services;
using MovieShop.ApplicationCore.Model;

namespace MovieShop.Infrastructure.Service
{
    public class MovieService : IMovieService
    {
        IMovieRepository moiveRepository;
        public MovieService(IMovieRepository _moiveRepository)
        {
           moiveRepository = _moiveRepository;
        }

        public async Task<MovieModel> GetMovieDetailsAsync(int id)
        {
            var entity = await moiveRepository.GetByIdAsync(id);

            if (entity != null)
            {
                MovieModel MoiveDetails = new MovieModel()
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    Overview = entity.Overview,
                    Tagline = entity.Tagline,
                    Budget = entity.Budget,
                    Revenue = entity.Revenue,
                    ImdbUrl = entity.ImdbUrl,
                    TmdbUrl = entity.TmdbUrl,
                    PosterUrl = entity.PosterUrl,
                    BackdropUrl = entity.BackdropUrl,
                    OriginalLanguage= entity.OriginalLanguage,
                    ReleaseDate = entity.ReleaseDate,
                    RunTime = entity.RunTime,
                    Price = entity.Price
                };
                return MoiveDetails;
            }
            return null;

        }
    }
}
