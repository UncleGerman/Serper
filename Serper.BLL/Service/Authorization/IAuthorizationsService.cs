using Microsoft.AspNetCore.Identity;
using Serper.BLL.Entity.Authorization;

namespace Serper.BLL.Service.Authorization
{
    public interface IAuthorizationsService
    {
        public Task<SignInResult> SignIn(IAuthorization authorizationParameters);

        public Task<IdentityResult> SignUp(IRegistration registrationParameters);

        public void SignOutAsync();
    }
}