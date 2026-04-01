
using SIGEApi.DTOs.AmbulanciaDtos;
using SIGEApi.Enums;
using SIGEApi.Models;
using SIGEApi.Repositories;

namespace SIGEApi.Services
{
    public class AmbulanciaService
    {
        private readonly AmbulanciaRepository _repository;
        public AmbulanciaService(AmbulanciaRepository repository)
        {
            _repository = repository;
        }
        public async Task<Ambulancia> CreateAmbulancia(AmbulanciaCreateDTO ambulanciaRequest)
        {
            if (await _repository.VerificarAmbulancia(ambulanciaRequest.Placa))
            {
                throw new ArgumentException("Ambulância já existente!");
            }
            var ambulancia = new Ambulancia
            {
                Placa = ambulanciaRequest.Placa,
                Marca = ambulanciaRequest.Marca,
                Modelo = ambulanciaRequest.Modelo,
                Tipo = ambulanciaRequest.Tipo,
                Status = StatusAmbulancia.Disponivel
            };
            return await _repository.CreateAmbulancia(ambulancia);
        }
        public async Task<Ambulancia> DeletarAmbulancia(Guid id)
        {
            var ambulancia = await _repository.GetAmbulanciaById(id);
            if (ambulancia == null)
            {
                throw new ArgumentException("Ambulância não encontrada!");
            }
            return await _repository.DeletarAmbulancia(ambulancia);
        }
        public async Task<Ambulancia> AtualizarAmbulancia(Guid id, AmbulanciaPatchDTO ambulanciaRequest)
        {
            var ambulancia = await _repository.GetAmbulanciaById(id);
            if (ambulancia == null)
            {
                throw new ArgumentException("Ambulância não encontrada!");
            }
            if (ambulancia.Placa.ToUpper() != ambulanciaRequest.Placa.ToUpper() && await _repository.VerificarAmbulancia(ambulanciaRequest.Placa))
            {
                throw new ArgumentException("Placa já existente!");
            }
            if (!string.IsNullOrEmpty(ambulanciaRequest.Placa))
            {
                ambulancia.Placa = ambulanciaRequest.Placa;
            }
            else if (!string.IsNullOrEmpty(ambulanciaRequest.Marca))
            {
                ambulancia.Marca = ambulanciaRequest.Marca;
            }
            else if (!string.IsNullOrEmpty(ambulanciaRequest.Modelo))
            {
                ambulancia.Modelo = ambulanciaRequest.Modelo;
            }
            else if (!string.IsNullOrEmpty(ambulanciaRequest.Tipo))
            {
                ambulancia.Tipo = ambulanciaRequest.Tipo;
            }
            return await _repository.AtualizarAmbulancia(ambulancia);
        }
        public async Task<Ambulancia> AtualizarStatusAmbulancia(Guid id, StatusAmbulancia status)
        {
            var ambulancia = await _repository.GetAmbulanciaById(id);
            if (ambulancia == null)
            {
                throw new ArgumentException("Ambulância não encontrada!");
            }
            ambulancia.Status = status;
            return await _repository.AtualizarAmbulancia(ambulancia);
        }
        public async Task<Ambulancia> GetAmbulanciaById(Guid id)
        {
            var ambulancia = await _repository.GetAmbulanciaById(id);
            if (ambulancia == null)
            {
                throw new ArgumentException("Ambulância não encontrada!");
            }
            return ambulancia;
        }
         public async Task<List<Ambulancia>> Listar(int pagina, int quantidade)
         {
            int pular = (pagina - 1) * quantidade;
            var ambulancias = await _repository.Listar(pular, quantidade);
            return ambulancias;
        }
    }
}
