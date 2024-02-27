using System.ComponentModel.DataAnnotations;

namespace RegistrationApp.Domein.Entities.DTOs
{
    public class LoginDTO
    {
        [EmailAddress]
        public string email { get; set; }

        public string password { get; set; }
    }
}
