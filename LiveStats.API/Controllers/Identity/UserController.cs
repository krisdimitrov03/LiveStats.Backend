using LiveStats.Core.Identity.Contracts;
using LiveStats.Core.Identity.Data.Models.Input;
using LiveStats.Core.Identity.Data.Models.Output;
using LiveStats.Infrastructure.Data.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LiveStats.API.Controllers.Identity
{

    public class UserController : BaseController
    {
        private readonly IUserService service;
        private readonly SignInManager<ApplicationUser> signInManager;

        public UserController(IUserService _service,
            SignInManager<ApplicationUser> _signInManager)
        {
            service = _service;
            signInManager = _signInManager;
        }

        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login([FromBody] LoginModel data)
        {
            var (success, token) = await service.LogUserIn(data);

            var result = new LoginReturnModel()
            {
                Success = success,
                Token = token
            };

            if (success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost(nameof(Register))]
        public async Task<IActionResult> Register([FromBody] RegisterModel data)
        {
            var (success, errors) = await service.RegisterUser(data);

            var result = new RegisterReturnModel() 
            { 
                Success = success, 
                Errors = errors 
            };

            if (success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet(nameof(Logout))]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await signInManager.SignOutAsync();

                return Ok(true);
            }
            catch (Exception)
            {
                return BadRequest(false);
            }
        }
    }
}
