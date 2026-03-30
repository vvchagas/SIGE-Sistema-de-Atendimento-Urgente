using Microsoft.AspNetCore.Identity;

namespace SIGEApi.Models
{
    public class Usuario : IdentityUser
    {        
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;    
        public string Cargo { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; }
    }
}
