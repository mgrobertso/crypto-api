using System.ComponentModel.DataAnnotations;


namespace Crypto.Core.DTOs
{
    public class CreateUserDto
    {
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "FirstName length too long")]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "LastName length too long")]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Username length too long")]
        public string Username { get; set; } = string.Empty;
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Password length too long")]
        public string Password { get; set; } = string.Empty;
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Email length too long")]
        public string Email { get; set; } = string.Empty;

    }
    public class UserDto : CreateUserDto
    {
        public Guid Id { get; set; }
    }

    public class LoginUserDto
    {

        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Username length too long")]
        public string Username { get; set; } = string.Empty;
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Password length too long")]
        public string Password { get; set; } = string.Empty;
    }

}