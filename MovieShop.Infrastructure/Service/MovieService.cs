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
                    Budget = (decimal)entity.Budget,
                    Revenue = (decimal)entity.Revenue,
                    ImdbUrl = entity.ImdbUrl,
                    TmdbUrl = entity.TmdbUrl,
                    PosterUrl = entity.PosterUrl,
                    BackdropUrl = entity.BackdropUrl,
                    OriginalLanguage= entity.OriginalLanguage,
                    ReleaseDate = entity.ReleaseDate,
                    RunTime = (int)entity.RunTime,
                    Price = entity.Price
                };
                return MoiveDetails;
            }
            return null;

        }

        public Task<IEnumerable<MovieCardModel>> GetMoviesByGenre(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MovieCardModel>> GetMoviesCast(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MovieCardModel>> GetTop30Movies()
        {
            var result = await moiveRepository.GetTop30Movies();
            var movieCard = new List<MovieCardModel>();
            if (result != null) {
                foreach (var item in result) 
                {
                    MovieCardModel mc = new MovieCardModel();
                    mc.Id = item.Id;
                    mc.Title = item.Title;
                    mc.PosterUrl = item.PosterUrl;
                    mc.ReleaseDate = item.ReleaseDate;
                    movieCard.Add(mc);
                }
            }
            return movieCard;
        }
    }
}
