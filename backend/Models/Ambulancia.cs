using SIGEApi.Enums;

namespace SIGEApi.Models
{
    public class Ambulancia
    {
        public Guid Id { get; set; }
        public string Placa { get; set; }
        public string? Marca { get; set; }
        public string Modelo { get; set; }
        public string Tipo { get; set; }
        public StatusAmbulancia Status { get; set; }
    }
}
