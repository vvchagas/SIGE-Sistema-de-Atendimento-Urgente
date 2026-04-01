namespace SIGEApi.DTOs.AuthDtos
{
    public class AutenticacaoRespostaDto
    {
        public bool Sucesso { get; set; }
        public string? Token { get; set; }
        public IEnumerable<string>? Erros { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Mensagem { get; set; } = string.Empty;
        public IList<string> Roles { get; set; } = new List<string>();
        public string Cargo { get; set; } = string.Empty;
    }
}
