using System.ComponentModel.DataAnnotations;

namespace crypto_api.Models
{
    public class UserDto
    {
        [Required]
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;



    }
}
