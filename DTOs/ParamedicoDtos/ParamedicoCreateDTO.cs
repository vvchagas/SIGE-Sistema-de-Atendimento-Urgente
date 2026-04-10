using System.ComponentModel.DataAnnotations;
namespace SIGEApi.DTOs.ParamedicoDtos
{
    public class ParamedicoCreateDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string IdentificadorProfissional { get; set; }

        [Required]
        public string Cargo { get; set; }

        [Required]
        public bool Ocupado { get; set; }
    }
}
