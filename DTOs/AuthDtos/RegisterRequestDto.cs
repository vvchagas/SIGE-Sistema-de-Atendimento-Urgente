using System.ComponentModel.DataAnnotations;

namespace SIGEApi.DTOs.AuthDtos
{
    public class RegisterRequestDto
    {
        [Required]
        public string Nome { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MaxLength(11)]
        public string Cpf { get; set; } = string.Empty;
        [Required]
        [Length(11, 11)]
        public string Telefone { get; set; } = string.Empty;
        [Required]
        public string Cargo { get; set; } = string.Empty;
        [Required]
        public string Senha { get; set; } = string.Empty;
    }
}
