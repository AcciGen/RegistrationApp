using System.ComponentModel.DataAnnotations;

namespace RegistrationApp.Domein.Entities.DTOs
{
    public class SignUpDTO
    {
        [EmailAddress]
        public string email { get; set; }

        public string password { get; set; }

        public string confirmPassword { get; set; }
    }
}
