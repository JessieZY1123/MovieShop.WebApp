using Microsoft.AspNetCore.Identity;
using MovieShop.ApplicationCore.Contracts.Repository;
using MovieShop.ApplicationCore.Contracts.Services;
using MovieShop.ApplicationCore.Model;

namespace MovieShop.Infrastructure.Service
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository userRepository;
        public AccountService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public Task<SignInResult> LoginAsync(SignInModel model)
        {
            return userRepository.LoginAsync(model);
        }

        public Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            return userRepository.SignUpAsync(model);
        }
    }
}
