using RegistrationApp.Domein.Entities.DTOs;
using RegistrationApp.Domein.Entities.Models;

namespace RegistrationApp.Application.Services.LoginServices
{
    public interface ILoginService
    {
        public Task<Login> SignUpAsync(SignUpDTO loginDTO);
        public Task<Login> SignInAsync(LoginDTO loginDTO);
        public Task<Login> SignInVerificationAsync(LoginDTO loginDTO);
    }
}
