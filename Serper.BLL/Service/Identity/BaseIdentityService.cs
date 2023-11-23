using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Serper.BLL.Entity;
using Serper.DAL.Entity.Identity;

namespace Serper.BLL.Service.Identity
{
    internal abstract class BaseIdentityService
    {
        protected BaseIdentityService(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager
                ?? throw new ArgumentNullException(nameof(userManager));

            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        private protected readonly UserManager<ApplicationUser> _userManager;

        private protected readonly IMapper _mapper;

        public async Task<IdentityResult> InsertAsync(ApplicationUserDTO applicationUserDTO)
        {
            var applicationUser = _mapper.Map<ApplicationUser>(applicationUserDTO);

            return await _userManager.CreateAsync(applicationUser, applicationUser.PasswordHash);
        }
    }
}