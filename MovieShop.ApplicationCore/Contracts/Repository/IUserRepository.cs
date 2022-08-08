using Microsoft.AspNetCore.Identity;
using MovieShop.ApplicationCore.Entities;
using MovieShop.ApplicationCore.Model;

namespace MovieShop.ApplicationCore.Contracts.Repository
{
    public interface IUserRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpModel user);
        Task<SignInResult> LoginAsync(SignInModel model);
    }
}
