using RegistrationApp.Domein.Entities.DTOs;
using RegistrationApp.Domein.Entities.Models;

namespace RegistrationApp.Application.Abstractions.Repositories
{
    public interface ILoginRepository
    {
        public Task<Login> SignUpAsync(Login login);
        public Task<Login> SignInAsync(LoginDTO loginDTO);
        public Task<Login> SignInVerificationAsync(LoginDTO loginDTO);

    }
}
