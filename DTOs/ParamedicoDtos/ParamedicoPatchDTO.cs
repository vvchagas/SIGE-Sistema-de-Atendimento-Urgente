namespace SIGEApi.DTOs.ParamedicoDtos
{
    public class ParamedicoPatchDTO
    {
        public string Name { get; set; }

        public string Cpf { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public string IdentificadorProfissional { get; set; }

        public string Cargo { get; set; }

        public bool Ocupado { get; set; }
    }
}
