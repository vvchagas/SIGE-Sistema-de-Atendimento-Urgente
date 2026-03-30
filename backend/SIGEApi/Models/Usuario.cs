using Microsoft.AspNetCore.Identity;

namespace SIGEApi.Models
{
    public class Usuario : IdentityUser
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;    
        public string Cargo { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; }
    }
}
