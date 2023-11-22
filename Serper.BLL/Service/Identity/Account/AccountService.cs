using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Serper.BLL.Entity;
using Serper.DAL.Entity.Identity;

namespace Serper.BLL.Service.Identity.Account
{
    internal sealed class AccountService : BaseIdentityService, IAccountService
    {
        public AccountService(
            UserManager<ApplicationUser> userManager,
            IMapper mapper,
            SignInManager<ApplicationUser> signInManager) : base(userManager, mapper)
        {
            _signInManager = signInManager
                ?? throw new ArgumentNullException(nameof(signInManager));
        }

        private readonly SignInManager<ApplicationUser> _signInManager;

        public async void SignInAsync(ApplicationUserDTO applicationUserDTO)
        {
            var applicationUser = _mapper.Map<ApplicationUser>(applicationUserDTO);

            await _signInManager.SignInAsync(applicationUser, false);
        }

        public async void PasswordSignInAsync(ApplicationUserDTO applicationUserDTO)
        {
            var applicationUser = _mapper.Map<ApplicationUser>(applicationUserDTO);

            var result = await _signInManager.PasswordSignInAsync(applicationUser, applicationUser.PasswordHash, false, false);

            if (result.Succeeded == false)
            {
                throw new InvalidOperationException("");
            }
        }

        public async void SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}