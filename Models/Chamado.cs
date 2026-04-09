using System.Diagnostics.CodeAnalysis;

namespace SIGEApi.Models
{
    public class Chamado
    {
        public Guid Id { get; set; }
        [NotNull]
        public string endereco { get; set; }
    }
}
