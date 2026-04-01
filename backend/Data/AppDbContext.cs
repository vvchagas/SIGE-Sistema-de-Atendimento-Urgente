using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SIGEApi.Models;

namespace SIGEApi.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options)
        : IdentityDbContext<Usuario>(options)
    {
        public DbSet<Ambulancia> Ambulancias => Set<Ambulancia>();
        public DbSet<Chamado> Chamados => Set<Chamado>();
        public DbSet<Paramedico> Paramedicos => Set<Paramedico>();
        public DbSet<ChamadoParamedico> ChamadosParamedicos => Set<ChamadoParamedico>();
    }
}
