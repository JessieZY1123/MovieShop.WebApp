using Microsoft.AspNetCore.Identity;
using MovieShop.ApplicationCore.Model;

namespace MovieShop.ApplicationCore.Contracts.Services
{
    public interface IAccountService
    {
        Task<IdentityResult> SignUpAsync(SignUpModel model);
        Task<SignInResult> LoginAsync(SignInModel model);
    }
}
