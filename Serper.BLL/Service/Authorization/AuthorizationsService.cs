using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Serper.DAL.Entity.Identity;
using Serper.BLL.Service.User;
using Serper.BLL.Entity.Authorization;
using Serper.BLL.Entity.Identity;

namespace Serper.BLL.Service.Authorization
{
    internal sealed class AuthorizationsService : IAuthorizationsService
    {
        public AuthorizationsService(
            IMapper mapper,
            IUserService userService,
            SignInManager<ApplicationUser> signInManager)
        {
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));

            _userService = userService
                ?? throw new ArgumentNullException(nameof(userService));

            _signInManager = signInManager
                ?? throw new ArgumentNullException(nameof(signInManager));
        }

        private readonly IMapper _mapper;

        private readonly IUserService _userService;

        private readonly SignInManager<ApplicationUser> _signInManager;

        public async Task<SignInResult> SignIn(IAuthorization authorizationParameters)
        {
            if (authorizationParameters is null)
            {
                throw new ArgumentNullException(nameof(authorizationParameters));
            }

            var result = await _signInManager.PasswordSignInAsync(
                authorizationParameters.Email,
                authorizationParameters.Password,
                authorizationParameters.RememberMe,
                false);

            return result;
        }

        public async Task<IdentityResult> SignUp(IRegistration registrationParameters)
        {
            if (registrationParameters is null)
            {
                throw new ArgumentNullException(nameof(registrationParameters));
            }

            var user = _mapper.Map<ApplicationUserDTO>(registrationParameters);

            var result = await _userService.InsertAsync(user);

            return result;
        }

        public async void SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}