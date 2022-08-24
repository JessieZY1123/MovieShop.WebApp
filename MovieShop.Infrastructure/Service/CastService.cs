using MovieShop.ApplicationCore.Contracts.Repository;
using MovieShop.ApplicationCore.Contracts.Services;
using MovieShop.ApplicationCore.Model;

namespace MovieShop.Infrastructure.Service
{
    public class CastService : ICastService
    {
        ICastRepository castRepository;
        public CastService(ICastRepository castRepository)
        {
            this.castRepository = castRepository;   
        }

        public async Task<CastDetailsModel> GetCastDetail(int id)
        {
            var CastDetails = await castRepository.GetByIdAsync(id);
            
            var castModel = new CastDetailsModel
            {
                Id = CastDetails.Id,
                Name = CastDetails.Name,
                Gender = CastDetails.Gender,
                TmdbUrl = CastDetails.TmdbUrl,
                ProfilePath = CastDetails.ProfilePath
            };

            castModel.Movies = new List<MovieCardModel>();

            foreach (var movie in CastDetails.MovieCasts)
            {
                castModel.Movies.Add(new MovieCardModel
                {
                    Id = movie.MovieId,
                    Title = movie.Movies.Title,
                    PosterUrl = movie.Movies.PosterUrl

                });
            }

            return castModel;
        }
    }
}
