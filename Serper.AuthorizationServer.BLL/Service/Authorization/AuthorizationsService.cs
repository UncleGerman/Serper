using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;
using Serper.DAL.Entity.Identity;
using Serper.AuthorizationServer.BLL.Entity.Authorization;
using Serper.BLL.Entity;
using Serper.BLL.Service.User;

[assembly: InternalsVisibleTo("Serper.Infrastructure")]
[assembly: InternalsVisibleTo("Serper.Tests")]
namespace Serper.AuthorizationServer.BLL.Service.Authorization
{
    internal class AuthorizationsService : IAuthorizationsService
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

        public async Task<SignInResult> SignIn(AuthorizationParameters authorizationParameters)
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

        public async Task<IdentityResult> SignUp(RegistrationParameters registrationParameters)
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