using MovieShop.ApplicationCore.Contracts.Repository;
using MovieShop.ApplicationCore.Contracts.Services;
using MovieShop.ApplicationCore.Model;

namespace MovieShop.Infrastructure.Service
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository genreRepository;
        public GenreService(IGenreRepository _genreRepository)
        {
            genreRepository = _genreRepository;
        }
        public async Task<IEnumerable<GenreModel>> GetAllGenres()
        {
            var genres = await genreRepository.GetAllAsync();
            List<GenreModel> listGenres= new List<GenreModel> ();
            if (genres != null) {
                foreach (var i in genres) { 
                GenreModel model = new GenreModel ();
                    model.Id = i.Id;   
                    model.Name = i.Name;
                    listGenres.Add(model);
                }
            }
            return listGenres;
        }
    }
}
