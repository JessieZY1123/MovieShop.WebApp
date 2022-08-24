using MovieShop.ApplicationCore.Model;

namespace MovieShop.ApplicationCore.Contracts.Services
{
    public interface ICastService
    {
        Task<CastDetailsModel> GetCastDetail(int id);
    }
}
