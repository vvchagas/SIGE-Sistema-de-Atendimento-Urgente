using System.ComponentModel.DataAnnotations;

namespace SIGEApi.DTOs.AuthDtos
{
    public class UserRole
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Role { get; set; } = string.Empty;
    }
}
