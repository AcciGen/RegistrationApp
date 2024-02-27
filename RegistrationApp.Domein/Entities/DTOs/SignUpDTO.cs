﻿using System.ComponentModel.DataAnnotations;

namespace RegistrationApp.Domein.Entities.DTOs
{
    public class SignUpDTO
    {
        [EmailAddress]
        public string email { get; set; }

        [MinLength(8)]
        public string password { get; set; }

        [MinLength(8)]
        public string confirmPassword { get; set; }
    }
}