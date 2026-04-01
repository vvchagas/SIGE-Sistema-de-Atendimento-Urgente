using Microsoft.EntityFrameworkCore;
using SIGEApi.Data;
using SIGEApi.Enums;
using SIGEApi.Models;

namespace SIGEApi.Repositories
{
    public class AmbulanciaRepository
    {
        private readonly AppDbContext _context;
        public AmbulanciaRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Ambulancia> CreateAmbulancia(Ambulancia novaAmbulancia)
        {
            _context.Ambulancias.Add(novaAmbulancia);
            await _context.SaveChangesAsync();
            return novaAmbulancia;
        }
        public async Task<bool> VerificarAmbulancia(string placa)
        {
            var ambulancia = await _context.Ambulancias.AnyAsync(a => a.Placa.ToUpper() == placa.ToUpper());
            return ambulancia;
        }
        public async Task<List<Ambulancia>> Listar(int pular, int pegar)
        {
            return await _context.Ambulancias

                  .OrderBy(c => !(c.Status == StatusAmbulancia.Disponivel))
                  .ThenBy(c => !(c.Status == StatusAmbulancia.EmUso))
                  .Skip(pular)
                  .Take(pegar)
                  .ToListAsync();
        }
        public async Task<Ambulancia?> GetAmbulanciaById(Guid id)
        {
            return await _context.Ambulancias.FindAsync(id);
        }
        public async Task<Ambulancia> DeletarAmbulancia(Ambulancia ambulancia)
        {            
            _context.Ambulancias.Remove(ambulancia);
            await _context.SaveChangesAsync();
            return ambulancia;
        }
        public async Task<Ambulancia> AtualizarAmbulancia(Ambulancia ambulancia)
        {
            _context.Ambulancias.Update(ambulancia);
            await _context.SaveChangesAsync();
            return ambulancia;
        }
    }
}
