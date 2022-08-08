using Microsoft.AspNetCore.Identity;
using MovieShop.ApplicationCore.Contracts.Repository;
using MovieShop.ApplicationCore.Entities;
using MovieShop.ApplicationCore.Model;

namespace MovieShop.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        public UserRepository(UserManager<User> userManager, SignInManager<User> s)
        {
            this.userManager = userManager;
            this.signInManager = s;
        }
        public Task<SignInResult> LoginAsync(SignInModel model)
        {
            return signInManager.PasswordSignInAsync(model.Email, model.Password, model.Remember, false);
        }
       
        public Task<IdentityResult> SignUpAsync(SignUpModel user)
        {   
            User appuser = new User();
            appuser.FirstName = user.FirstName;
            appuser.LastName = user.LastName;
            appuser.Email = user.Email;
            appuser.UserName = user.Email;

            return  userManager.CreateAsync(appuser, user.Password);
        }

    }
}
