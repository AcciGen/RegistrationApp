using RegistrationApp.Application.Abstractions.Repositories;
using RegistrationApp.Domein.Entities.DTOs;
using RegistrationApp.Domein.Entities.Models;

namespace RegistrationApp.Application.Services.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
            => _loginRepository = loginRepository;

        public async Task<Login> SignUpAsync(LoginDTO loginDTO)
        {
            var credentials = new Login()
            {
                email = loginDTO.email,
                password = loginDTO.password
            };

            credentials = await _loginRepository.SignUpAsync(credentials);

            return credentials;
        }

        public async Task<Login> SignInAsync(LoginDTO loginDTO)
        {
            var verify = await _loginRepository.SignInAsync(loginDTO);

            return verify;
        }

        public async Task<Login> SignInVerificationAsync(LoginDTO loginDTO)
        {
            var verify = await _loginRepository.SignInVerificationAsync(loginDTO);

            return verify;
        }

    }
}
