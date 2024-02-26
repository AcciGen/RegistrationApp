using Microsoft.EntityFrameworkCore.ChangeTracking;
using RegistrationApp.Domein.Entities.DTOs;
using RegistrationApp.Domein.Entities.Models;
using RegistrationApp.Infrastructure.Persistance;
using System.Data.Entity;

namespace RegistrationApp.Infrastructure.Repository
{
    public class LoginRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LoginRepository(ApplicationDbContext dbContext)
            => _dbContext = dbContext;

        public async Task<Login> SignUpAsync(Login login)
        {
            var storedLogin = await _dbContext.Logins.FirstOrDefaultAsync(x => x.email == login.email);

            if (storedLogin is null)
            {
                EntityEntry<Login> entry = await _dbContext.AddAsync(login);
                await _dbContext.SaveChangesAsync();

                return entry.Entity;
            }

            return null!;
        }

        public async Task<Login> SignInAsync(LoginDTO loginDTO, int code)
        {
            var storedLogin = await _dbContext.Logins.FirstOrDefaultAsync(x => x.email == loginDTO.email && x.password == loginDTO.password);

            if (storedLogin is null)
                return null!;

            return storedLogin;
        }

        public async Task<Login> SignInVerificationAsync(LoginDTO loginDTO)
        {
            var storedLogin = await _dbContext.Logins.FirstOrDefaultAsync(x => x.email == loginDTO.email && x.verificationPassword == loginDTO.password);

            if (storedLogin is null)
                return null!;

            return storedLogin;
        }
    }
}
