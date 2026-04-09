using System.ComponentModel.DataAnnotations;

namespace SIGEApi.DTOs.AuthDtos
{
    public class LoginRequestDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Senha { get; set; } = string.Empty;
    }
}
