﻿using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> SignUpAsync(LoginDTO model)
        {
            var verify = await _loginService.SignInAsync(model);

            if (verify != null)
            {
                return Ok(verify);
            }

            return BadRequest("You've already signed up!");
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
    }