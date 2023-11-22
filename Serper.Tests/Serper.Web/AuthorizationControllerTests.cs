using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Serper.AuthorizationServer.BLL.Entity.Authorization;
using Serper.AuthorizationServer.BLL.Service.JWTToken;
using Serper.AuthorizationServer.Controllers;
using Serper.BLL.Entity;
using Serper.BLL.Entity.Authorization;
using Serper.BLL.Service.Authorization;
using Serper.BLL.Service.User;

namespace Serper.Tests.Serper.Web
{
    public class AuthorizationControllerTests
    {
        public AuthorizationControllerTests()
        {
            _JWTTokenService = new Mock<IJWTTokenService>().Object;

            _authorizationsService = new Mock<IAuthorizationsService>();

            _userService = new Mock<IUserService>();
        }

        private readonly IJWTTokenService _JWTTokenService;

        private readonly Mock<IAuthorizationsService> _authorizationsService;

        private readonly Mock<IUserService> _userService;

        private readonly AuthorizationParameters _authorizationParameters = new()
        {
            Email = "test@net"
        };

        #region SignUp

        [Fact]
        public async Task SignUp_PassNullObject_ReturnBadReqest()
        {
            var authorizationController = new AuthorizationController(
                _authorizationsService.Object,
                _userService.Object,
                _JWTTokenService);

            var result = await authorizationController.SignIn(null);

            var objectResult = (ObjectResult)result;

            Assert.Equal(400, objectResult.StatusCode);
        }

        [Fact]
        public async Task SignUp_TaskDone_ReturnCreated()
        {
            _authorizationsService.Setup(authorizationsService =>
            authorizationsService.SignUp(It.IsAny<RegistrationParameters>()))
                .Returns(Task.FromResult(IdentityResult.Success));

            var authorizationController = new AuthorizationController(
               _authorizationsService.Object,
               _userService.Object,
               _JWTTokenService);

            var result = await authorizationController.SignUp(new RegistrationParameters());

            var objectResult = (ObjectResult)result;

            Assert.Equal(201, objectResult.StatusCode);
        }

        [Fact]
        public async Task SignUp_TaskFailed_ReturnBadReqest()
        {
            _authorizationsService.Setup(authorizationsService =>
            authorizationsService.SignUp(It.IsAny<RegistrationParameters>()))
                .Returns(Task.FromResult(IdentityResult.Failed()));

            var authorizationController = new AuthorizationController(
               _authorizationsService.Object,
               _userService.Object,
               _JWTTokenService);

            var result = await authorizationController.SignIn(new AuthorizationParameters());

            var objectResult = (ObjectResult)result;

            Assert.Equal(400, objectResult.StatusCode);
        }

        #endregion

        #region SignIn

        [Fact]
        public async Task SignIn_PassNullObject_ReturnBadReqest()
        {
            var authorizationController = new AuthorizationController(
               _authorizationsService.Object,
               _userService.Object,
               _JWTTokenService);

            var result = await authorizationController.SignIn(null);

            var objectResult = (ObjectResult)result;

            Assert.Equal(400, objectResult.StatusCode);

            Assert.Equal("AuthorizationParameters not be null", objectResult.Value.ToString());
        }

        [Fact]
        public async Task SignIn_TaskDone_ReturnToken()
        {
            _userService.Setup(userService =>
            userService.GetByEmailAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(new ApplicationUserDTO()));

            _authorizationsService.Setup(authorizationsService =>
            authorizationsService.SignIn(It.IsAny<AuthorizationParameters>()))
                .Returns(Task.FromResult(
                    Microsoft.AspNetCore.Identity.SignInResult.Success));

            var jWTTokenService = new Mock<IJWTTokenService>();

            jWTTokenService.Setup(jWTTokenService =>
            jWTTokenService.Generate(It.IsAny<ApplicationUserDTO>()))
                .Returns("testToken");

            var authorizationController = new AuthorizationController(
               _authorizationsService.Object,
               _userService.Object,
               jWTTokenService.Object);

            var result = await authorizationController.SignIn(_authorizationParameters);

            var objectResult = (ObjectResult)result;

            Assert.Equal(200, objectResult.StatusCode);

            Assert.Equal("testToken", objectResult.Value.ToString());
        }

        [Fact]
        public async Task SignIn_PassObjectPropertyEmpty_ReturnBadReqest()
        {
            var authorizationController = new AuthorizationController(
               _authorizationsService.Object,
               _userService.Object,
               _JWTTokenService);

            var result = await authorizationController.SignIn(new AuthorizationParameters());

            var objectResult = (ObjectResult)result;

            Assert.Equal(400, objectResult.StatusCode);

            Assert.Equal("Email not be empty", objectResult.Value.ToString());
        }

        [Fact]
        public async Task SignIn_PassNullObject_ReturnNotFound()
        {
            ApplicationUserDTO applicationUserDTO = null;

            _userService.Setup(userService =>
            userService.GetByEmailAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(applicationUserDTO));

            var authorizationController = new AuthorizationController(
               _authorizationsService.Object,
               _userService.Object,
               _JWTTokenService);

            var result = await authorizationController.SignIn(_authorizationParameters);

            var objectResult = (ObjectResult)result;

            Assert.Equal(404, objectResult.StatusCode);
        }

        [Fact]
        public async Task SignIn_TaskFailed_ReturnBadReqest()
        {
            _userService.Setup(userService =>
            userService.GetByEmailAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(new ApplicationUserDTO()));

            _authorizationsService.Setup(authorizationsService =>
            authorizationsService.SignIn(It.IsAny<AuthorizationParameters>()))
                .Returns(Task.FromResult(
                    Microsoft.AspNetCore.Identity.SignInResult.Failed));

            var authorizationController = new AuthorizationController(
               _authorizationsService.Object,
               _userService.Object,
               _JWTTokenService);

            var result = await authorizationController.SignIn(_authorizationParameters);

            var objectResult = (ObjectResult)result;

            Assert.Equal(400, objectResult.StatusCode);
        }

        #endregion

    }
}
