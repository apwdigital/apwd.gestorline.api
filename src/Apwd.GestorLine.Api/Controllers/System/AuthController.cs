using Apwd.GestorLine.Domain.Models.v1.System;
using Apwd.GestorLine.Services.Contracts.v1.System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Apwd.GestorLine.Api.Controllers.System
{
    [ApiController]
    [Route("api/v1/auth")]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<AuthController> _logger;
        public AuthController(
            IUserService userService,
            ILogger<AuthController> logger)
        {
            _userService = userService;
            _logger = logger;
        }


        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> AuthenticateOLD([FromBody] UserLoginModel model)
        {
            model.UserCode = $"{model.UserCode}RiwVUAOjC=5s2Vmw7e0B";

            var user = await _userService.GetLogin(model);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = "XPTO001";

            var createdDate = DateTime.Now;

            _logger.LogInformation($"[{DateTime.UtcNow}] login successful");

            return new
            {
                username = user.UserName,
                companyId = user.CompanyId,
                siteCodeInformation = user.Id,
                siteCodeValidation = string.Empty, //AppHelper.GetAccountLevelCode(user.AccountLevel),
                appVersion = "V25.3.27",
                token,
                createdDate,
                changedDate = new DateTime(createdDate.Year, createdDate.Month, createdDate.Day, 0, 0, 0),
            };
        }

        [HttpPost]
        public async Task<UserModel> Add(AddUserModel obj)
        {
            var objAdded = await _userService.Add(obj);
            return objAdded;
        }
    }
}