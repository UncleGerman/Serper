using Microsoft.AspNetCore.Identity;
using Serper.BLL.Entity;

namespace Serper.BLL.Service.Identity.Account
{
    public interface IAccountService
    {
        public Task<IdentityResult> InsertAsync(ApplicationUserDTO applicationUserDTO);

        public void SignInAsync(ApplicationUserDTO applicationUserDTO);

        public void PasswordSignInAsync(ApplicationUserDTO applicationUserDTO);

        public void SignOutAsync();
    }
}