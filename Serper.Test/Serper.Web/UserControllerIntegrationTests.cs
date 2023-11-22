using AutoMapper;
using MockQueryable.Moq;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using Serper.DAL.Entity;
using Serper.DAL.Entity.Identity;
using Serper.Infrastructure.AutoMapper;
using Serper.BLL.Service.Identity.User;
using Serper.BLL.Service.User;
using Serper.BLL.Entity.Identity;

namespace Serper.Tests.Serper.ResourceServer
{
    public class UserControllerIntegrationTests
    {
        public UserControllerIntegrationTests()
        {
            _userService = GetInitializedUserService();
        }

        private readonly IUserService _userService;

        #region InsertAsync

        [Fact]
        public async Task InsertAsync_TaskDone_ReturnCreated()
        {
            var userController = new UserController(_userService);

            var applicationUserDTO = new ApplicationUserDTO()
            {
                RoleName = "User"
            };

            var result = await userController.InsertAsync(applicationUserDTO);

            var objectResult = (ObjectResult)result;

            Assert.Equal(201, objectResult.StatusCode);
        }

        [Fact]
        public async Task InsertAsync_CreatedTaskFailed_ReturnBadReqest()
        {
            var userManager = GetUserManager();

            var mapper = GetMapper();

            var passwordHasher = GetPasswordHasher();

            userManager.Setup(userManager => userManager.CreateAsync(It.IsAny<ApplicationUser>()))
                       .Returns(Task.FromResult(IdentityResult.Failed()));

            var userService = new UserService(userManager.Object, mapper, passwordHasher);

            var userController = new UserController(userService);

            var result = await userController.InsertAsync(new ApplicationUserDTO());

            var objectResult = (ObjectResult)result;

            Assert.Equal(400, objectResult.StatusCode);
        }

        [Fact]
        public async Task InsertAsync_AddRoleTaskFailed_ReturnBadReqest()
        {
            var userManager = GetUserManager();

            var mapper = GetMapper();

            var passwordHasher = GetPasswordHasher();

            userManager.Setup(userManager => userManager.AddToRoleAsync(It.IsAny<ApplicationUser>(),
                It.IsAny<string>()))
                .Returns(Task.FromResult(IdentityResult.Failed()));

            var userService = new UserService(userManager.Object, mapper, passwordHasher);

            var userController = new UserController(userService);

            var result = await userController.InsertAsync(new ApplicationUserDTO());

            var objectResult = (ObjectResult)result;

            Assert.Equal(400, objectResult.StatusCode);
        }

        [Fact]
        public async Task InsertAsync_AddClaimTaskFailed_ReturnBadReqest()
        {
            var userManager = GetUserManager();

            var mapper = GetMapper();

            var passwordHasher = GetPasswordHasher();

            userManager.Setup(userManager => userManager.AddClaimAsync(It.IsAny<ApplicationUser>(),
                It.IsAny<Claim>()))
                .Returns(Task.FromResult(IdentityResult.Failed()));

            var userService = new UserService(userManager.Object, mapper, passwordHasher);

            var userController = new UserController(userService);

            var result = await userController.InsertAsync(new ApplicationUserDTO());

            var objectResult = (ObjectResult)result;

            Assert.Equal(400, objectResult.StatusCode);
        }

        [Fact]
        public async Task InsertAsync_PassEmptyRoleName_ReturnBadReqest()
        {
            var userController = new UserController(_userService);

            var result = await userController.InsertAsync(new ApplicationUserDTO());

            var objectResult = (ObjectResult)result;

            Assert.Equal(400, objectResult.StatusCode);
        }

        [Fact]
        public async Task InsertAsync_PassNullObject_ReturnBadReqest()
        {
            var userController = new UserController(_userService);

            var result = await userController.InsertAsync(null);

            var objectResult = (ObjectResult)result;

            Assert.Equal(400, objectResult.StatusCode);
        }

        #endregion

        #region UpdateAsync

        [Fact]
        public async Task UpdateAsync_TaskDone_ReturnOk()
        {
            var userController = new UserController(_userService);

            var result = await userController.UpdateAsync(new ApplicationUserDTO());

            var objectResult = (ObjectResult)result;

            Assert.Equal(200, objectResult.StatusCode);
        }

        [Fact]
        public async Task UpdateAsync_TaskFailed_ReturnBadReqest()
        {
            var userManager = GetUserManager();

            var mapper = GetMapper();

            var passwordHasher = GetPasswordHasher();

            userManager.Setup(userManager => userManager.UpdateAsync(It.IsAny<ApplicationUser>()))
                       .Returns(Task.FromResult(IdentityResult.Failed()));

            var userService = new UserService(userManager.Object, mapper, passwordHasher);

            var userController = new UserController(userService);

            var result = await userController.UpdateAsync(new ApplicationUserDTO());

            var objectResult = (ObjectResult)result;

            Assert.Equal(204, objectResult.StatusCode);
        }

        [Fact]
        public async Task UpdateAsync_PassNullObject_ReturnBadReqest()
        {
            var userController = new UserController(_userService);

            var result = await userController.UpdateAsync(null);

            var objectResult = (ObjectResult)result;

            Assert.Equal(400, objectResult.StatusCode);
        }

        #endregion

        #region RemoveAsync

        [Fact]
        public async Task RemoveAsync_TaskDone_ReturnOk()
        {
            var userController = new UserController(_userService);

            var result = await userController.RemoveAsync("testId");

            var objectResult = (ObjectResult)result;

            Assert.Equal(202, objectResult.StatusCode);
        }

        [Fact]
        public async Task RemoveAsync_TaskFailed_ReturnBadReqest()
        {
            var userManager = GetUserManager();

            var mapper = GetMapper();

            var passwordHasher = GetPasswordHasher();

            userManager.Setup(userManager => userManager.DeleteAsync(It.IsAny<ApplicationUser>()))
                       .Returns(Task.FromResult(IdentityResult.Failed()));

            userManager.Setup(userManager => userManager.FindByIdAsync(It.IsAny<string>()))
                       .Returns(Task.FromResult(new ApplicationUser()));

            var userService = new UserService(userManager.Object, mapper, passwordHasher);

            var userController = new UserController(userService);

            var result = await userController.RemoveAsync("stringId");

            var objectResult = (ObjectResult)result;

            Assert.Equal(400, objectResult.StatusCode);
        }

        [Fact]
        public async Task RemoveAsync_PassEmptyId_ReturnBadReqest()
        {
            var userController = new UserController(_userService);

            var result = await userController.RemoveAsync("");

            var objectResult = (ObjectResult)result;

            Assert.Equal(400, objectResult.StatusCode);
        }

        #endregion

        #region GeById

        [Fact]
        public async Task GetByIdAsync_TaskDone_ReturnOkObject()
        {
            var applicationUserDTO = new ApplicationUserDTO()
            {
                UserName = "test"
            };

            var userController = new UserController(_userService);

            var result = await userController.GetByIdAsync("stringId");

            var objectResult = (ObjectResult)result;

            var user = (ApplicationUserDTO)objectResult.Value;

            Assert.Equal(applicationUserDTO.UserName, user.UserName);

            Assert.Equal(200, objectResult.StatusCode);
        }

        [Fact]
        public async Task GetByIdAsync_PassEmptyId_ReturnBadReqest()
        {
            var userController = new UserController(_userService);

            var result = await userController.GetByIdAsync("");

            var objectResult = (ObjectResult)result;

            Assert.Equal(400, objectResult.StatusCode);
        }

        #endregion

        [Fact]
        public void GetAll_GetCollection_ReturnCollection()
        {
            var userController = new UserController(_userService);

            var result = userController.GetAll();

            var objectResult = (ObjectResult)result;

            var usersDTO = (IEnumerable<ApplicationUserDTO>)objectResult.Value;

            Assert.Single(usersDTO);

            Assert.Equal(200, objectResult.StatusCode);
        }

        private Mock<UserManager<ApplicationUser>> GetUserManager()
        {
            var userManager = new Mock<UserManager<ApplicationUser>>(
                new Mock<IUserStore<ApplicationUser>>().Object,
                new Mock<IOptions<IdentityOptions>>().Object,
                new Mock<IPasswordHasher<ApplicationUser>>().Object,
                new IUserValidator<ApplicationUser>[0],
                new IPasswordValidator<ApplicationUser>[0],
                new Mock<ILookupNormalizer>().Object,
                new Mock<IdentityErrorDescriber>().Object,
                new Mock<IServiceProvider>().Object,
                new Mock<ILogger<UserManager<ApplicationUser>>>().Object);

            #region UserManager Setup

            var users = new List<ApplicationUser>()
            {
                new ApplicationUser()
                {
                    UserName = "test",
                    Email = "test@net",
                    SearchResults = new List<SearchResult>()
                    {
                        new SearchResult()
                    }
                },
            }.AsQueryable().BuildMock();

            userManager.Setup(userManager => userManager.CreateAsync(
                    It.IsAny<ApplicationUser>(),
                    It.IsAny<string>()))
                .Returns(Task.FromResult(IdentityResult.Success));

            userManager.Setup(userManager => userManager.AddToRoleAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<string>()))
                 .Returns(Task.FromResult(IdentityResult.Success));

            userManager.Setup(userManager => userManager.AddClaimAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<Claim>()))
                 .Returns(Task.FromResult(IdentityResult.Success));

            userManager.Setup(userManager => userManager.DeleteAsync(
                    It.IsAny<ApplicationUser>()))
                .Returns(Task.FromResult(IdentityResult.Success));

            userManager.Setup(userManager => userManager.UpdateAsync(
                    It.IsAny<ApplicationUser>()))
                .Returns(Task.FromResult(IdentityResult.Success));

            userManager.Setup(userManager => userManager.Users)
                .Returns(users);

            #endregion

            return userManager;
        }

        private IMapper GetMapper()
        {
            var identityProfile = new IdentityProfile();

            var configuration = new MapperConfiguration(mapperConfiguration => 
                mapperConfiguration.AddProfile(identityProfile));

            var mapper = new Mapper(configuration);

            return mapper;
        }

        private IPasswordHasher<ApplicationUser> GetPasswordHasher()
        {
            var passwordHasher = new Mock<IPasswordHasher<ApplicationUser>>();

            passwordHasher
                .Setup(passwordHasher => passwordHasher.HashPassword(
                    It.IsAny<ApplicationUser>(),
                    It.IsAny<string>()))
                .Returns("Hash value");

            return passwordHasher.Object;
        }

        private IUserService GetInitializedUserService()
        {
            var userManager = GetUserManager();

            var mapper = GetMapper();

            var passwordHasher = GetPasswordHasher();

            var userService = new UserService(
                userManager.Object,
                mapper,
                passwordHasher);

            return userService;
        }
    }
}