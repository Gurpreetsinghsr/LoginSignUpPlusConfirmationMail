using ConformationEmail.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ConformationEmail.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);

        Task<SignInResult> PasswordSignInAsync(SignInModel signInModel);
    }
}