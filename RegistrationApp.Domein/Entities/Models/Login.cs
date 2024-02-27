using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RegistrationApp.Domein.Entities.Models
{
    public class Login
    {
        public int id { get; set; }

        [EmailAddress]
        public required string email { get; set; }

        [MinLength(8)]
        public required string password { get; set; }

        [JsonIgnore]
        public string? verificationPassword { get; set; }
    }
}
