using Microsoft.AspNetCore.Identity;
using Serper.AuthorizationServer.BLL.Entity.Authorization;

namespace Serper.AuthorizationServer.BLL.Service.Authorization
{
    public interface IAuthorizationsService
    {
        public Task<SignInResult> SignIn(AuthorizationParameters authorizationParameters);

        public Task<IdentityResult> SignUp(RegistrationParameters registrationParameters);

        public void SignOutAsync();
    }
}