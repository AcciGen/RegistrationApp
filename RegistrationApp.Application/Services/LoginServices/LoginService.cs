using Microsoft.EntityFrameworkCore;
using RegistrationApp.Domein.Entities.DTOs;
using RegistrationApp.Domein.Entities.Models;
using RegistrationApp.Infrastructure.Persistance;
using System.Data.Entity;

namespace RegistrationApp.Application.Services.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly ApplicationDbContext _context;

        public LoginService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Login> SignUpAsync(SignUpDTO loginDTO)
        {
            if (loginDTO.password == loginDTO.confirmPassword)
            {
                var model = new Login()
                {
                    email = loginDTO.email,
                    password = loginDTO.password
                };

                await _context.Logins.AddAsync(model);

                await _context.SaveChangesAsync();
                
                return model;
            }

            return null!;

        }

        public async Task<Login> SignInAsync(LoginDTO loginDTO)
        {
            var storedLogin = await _context.Logins.FirstOrDefaultAsync(x => x.email == loginDTO.email && x.password == loginDTO.password);

            if (storedLogin is null)
                return null!;

            return storedLogin;
        }

        public async Task<Login> SignInVerificationAsync(LoginDTO loginDTO)
        {
            var storedLogin = await _context.Logins.FirstOrDefaultAsync(x => x.email == loginDTO.email && x.verificationPassword == loginDTO.password);

            if (storedLogin is null)
                return null!;

            return storedLogin;
        }

    }
}
