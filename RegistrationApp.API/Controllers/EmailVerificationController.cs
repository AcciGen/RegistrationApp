using Microsoft.AspNetCore.Mvc;
using RegistrationApp.Application.Services.LoginServices;
using RegistrationApp.Domein.Entities.DTOs;

namespace RegistrationApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmailVerificationController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public EmailVerificationController(ILoginService loginService)
            => _loginService = loginService;

        [HttpPost]
        public async Task<IActionResult> SignUpAsync(SignUpDTO model)
        {
            var verify = await _loginService.SignUpAsync(model);

            if (verify != null)
            {
                return Ok(verify);
            }

            return BadRequest("You've already signed up or your confirmation password is not same with the password!");
        }

        [HttpGet]
        public async Task<IActionResult> SignInAsync(LoginDTO model)
        {
            var verify = await _loginService.SignInAsync(model);

            if (verify != null)
            {
                return Ok("Please enter the code, which we've sent to you, to the next api...");
            }

            return BadRequest("You're not found!\nPlease Sign Up first!");
        }

        [HttpGet]
        public async Task<IActionResult> SignInVerificationAsync(LoginDTO model)
        {
            var verify = await _loginService.SignInVerificationAsync(model);

            if (verify != null)
            {
                return Ok("Congratulations!\nYou're logged in!");
            }

            return BadRequest("Something went wrong!");
        }
    }
}