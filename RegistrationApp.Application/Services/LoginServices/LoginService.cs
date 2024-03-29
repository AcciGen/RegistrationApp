﻿using Microsoft.EntityFrameworkCore;
using RegistrationApp.Domein.Entities.DTOs;
using RegistrationApp.Domein.Entities.Models;
using RegistrationApp.Infrastructure.Persistance;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace RegistrationApp.Application.Services.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;

        public LoginService(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<Login> SignUpAsync(SignUpDTO loginDTO)
        {
            if (loginDTO.password == loginDTO.confirmPassword)
            {
                var storedLogin = await _context.Logins
                    .FirstOrDefaultAsync(x => x.email == loginDTO.email);

                if (storedLogin is not null)
                    return null!;

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

        public async Task<Login> SignInAsync(LoginDTO model)
        {
            var storedLogin = await _context.Logins
                .FirstOrDefaultAsync(x => x.email == model.email && x.password == model.password);

            if (storedLogin is null)
                return null!;

            Random random = new Random();
            string code = $"{random.Next(1000, 9999)}";


            var emailSettings = _config.GetSection("EmailSettings");
            var mailMessage = new MailMessage
            {
                From = new MailAddress(emailSettings["Sender"], emailSettings["SenderName"]),
                Subject = "Unique Code",
                Body = code,
                IsBodyHtml = true,

            };
            mailMessage.To.Add(model.email);

            using var smtpClient = new SmtpClient(emailSettings["MailServer"], int.Parse(emailSettings["MailPort"]))
            {
                Port = Convert.ToInt32(emailSettings["MailPort"]),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(emailSettings["Sender"], emailSettings["Password"]),
                EnableSsl = true,
            };

            //smtpClient.UseDefaultCredentials = true;

            await smtpClient.SendMailAsync(mailMessage);


            var login = await _context.Logins.FirstAsync(x => x.email == model.email);

            login.verificationPassword = code;
            await _context.SaveChangesAsync();

            return storedLogin;
        }

        public async Task<Login> SignInVerificationAsync(LoginDTO loginDTO)
        {
            var storedLogin = await _context.Logins.FirstOrDefaultAsync(x => x.email == loginDTO.email && x.verificationPassword == loginDTO.password);

            if (storedLogin is null)
                return null!;

            storedLogin.verificationPassword = null;

            await _context.SaveChangesAsync();

            return storedLogin;
        }

    }
}
