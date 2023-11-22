using AutoMapper;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serper.BLL.Entity;
using Serper.DAL.Entity.Identity;
using Serper.BLL.Entity.Identity;

namespace Serper.BLL.Service.User
{
    internal sealed class UserService : IUserService
    {
        public UserService(
            UserManager<ApplicationUser> userManager,
            IMapper mapper,
            IPasswordHasher<ApplicationUser> passwordHasher)
        {
            _userManager = userManager
                ?? throw new ArgumentNullException(nameof(userManager));

            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));

            _passwordHasher = passwordHasher
                ?? throw new ArgumentNullException(nameof(passwordHasher));
        }

        private readonly IMapper _mapper;

        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;

        private readonly UserManager<ApplicationUser> _userManager;

        public async Task<IdentityResult> InsertAsync(ApplicationUserDTO applicationUserDTO)
        {
            if (applicationUserDTO is null)
            {
                throw new ArgumentNullException(nameof(applicationUserDTO));
            }

            var applicationUser = _mapper.Map<ApplicationUser>(applicationUserDTO);

            var passwordHash = _passwordHasher.HashPassword(applicationUser, applicationUser.PasswordHash);

            var result = await _userManager.CreateAsync(
                applicationUser,
                passwordHash);

            return result;
        }

        public async Task<IdentityResult> RemoveAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException(nameof(id), "Id can not be empty");
            }

            var applicationUser = await _userManager.FindByIdAsync(id);

            var result = await _userManager.DeleteAsync(applicationUser);

            return result;
        }

        public async Task<IdentityResult> UpdateAsync(ApplicationUserDTO applicationUserDTO)
        {
            if (applicationUserDTO is null)
            {
                throw new ArgumentNullException(nameof(applicationUserDTO));
            }

            var applicationUser = _mapper.Map<ApplicationUser>(applicationUserDTO);

            var result = await _userManager.UpdateAsync(applicationUser);

            return result;
        }

        #region Get

        public async Task<ApplicationUserDTO> GetByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException(nameof(email));
            }

            var applicationUser = await _userManager.Users
                .FirstOrDefaultAsync(applicationUser => applicationUser.Email == email);

            var applicationUserDTO = _mapper.Map<ApplicationUserDTO>(applicationUser);

            return applicationUserDTO;
        }

        public async Task<ApplicationUserDTO> GetByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            var applicationUser = await _userManager.Users
                .FirstOrDefaultAsync(applicationUser => applicationUser.Id == id);

            var applicationUserDTO = _mapper.Map<ApplicationUserDTO>(applicationUser);

            return applicationUserDTO;
        }

        public IReadOnlyCollection<ApplicationUserDTO> GetAll()
        {
            var applicationUsers = _userManager.Users.ToList();

            var applicationUsersDTO = _mapper.Map<IReadOnlyCollection<ApplicationUserDTO>>(applicationUsers);

            return applicationUsersDTO;
        }

        #endregion

        #region User Role

        public async Task<IdentityResult> AddRoleAsync(ApplicationUserDTO applicationUserDTO, string role)
        {
            var applicationUser = _mapper.Map<ApplicationUser>(applicationUserDTO);

            var result = await _userManager.AddToRoleAsync(applicationUser, role);

            if (result.Succeeded)
            {
                var claimResult = await AddClaimRoleAsync(applicationUser, role);

                return claimResult;
            }

            return result;
        }

        public async Task<IdentityResult> RemoveRoleAsync(ApplicationUserDTO applicationUserDTO, string role)
        {
            var applicationUser = _mapper.Map<ApplicationUser>(applicationUserDTO);

            var result = await _userManager.RemoveFromRoleAsync(applicationUser, role);

            if (result.Succeeded)
            {
                var claimResult = await RemoveClaimRoleAsync(applicationUser, role);

                return claimResult;
            }

            return result;
        }

        #endregion

        #region User Claim

        private async Task<IdentityResult> AddClaimRoleAsync(ApplicationUser applicationUser, string role)
        {
            var claim = new Claim(ClaimTypes.Role, role);

            var result = await _userManager.AddClaimAsync(applicationUser, claim);

            return result;
        }

        private async Task<IdentityResult> RemoveClaimRoleAsync(ApplicationUser applicationUser, string role)
        {
            var claims = await _userManager.GetClaimsAsync(applicationUser);

            var claim = claims.FirstOrDefault(claim => claim.Value == role);

            var result = await _userManager.RemoveClaimAsync(applicationUser, claim);

            return result;
        }

        #endregion

        public async Task<IReadOnlyCollection<SearchResultDTO>> GetUserSearchResults(string id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(s => s.Id == id);

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var userSearchResults = user.SearchResults.ToList();

            var userSearchResultsDTO = _mapper.Map<IReadOnlyCollection<SearchResultDTO>>(userSearchResults);

            return userSearchResultsDTO;
        }
    }
}