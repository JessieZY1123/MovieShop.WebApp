using MovieShop.ApplicationCore.Model;

namespace MovieShop.ApplicationCore.Contracts.Services
{
    public interface ICastService
    {
        Task<CastModel> GetCastDetail(int id);
    }
}
