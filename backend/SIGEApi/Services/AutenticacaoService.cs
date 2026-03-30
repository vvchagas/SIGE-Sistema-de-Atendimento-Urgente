using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIGEApi.Data;
using SIGEApi.DTOs.AuthDtos;
using SIGEApi.Models;

namespace SIGEApi.Services
{
    public class AutenticacaoService
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;

        public AutenticacaoService(UserManager<Usuario> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, AppDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _context = context;
        }

        public async Task<IdentityResult> Registrar([FromBody] RegisterRequestDto request)
        {
            if (await _context.Users.AnyAsync(u => u.Cpf == request.Cpf))
            { 
                return IdentityResult.Failed(new IdentityError
                {
                    Code = "CpfDuplicado",
                    Description = "Este CPF já está cadastrado no sistema."
                });
            }
            var novoUsuario = new Usuario
            {
                UserName = request.Email,
                Email = request.Email,
                Nome = request.Nome,
                Cpf = request.Cpf,
                PhoneNumber = request.Telefone,
                Cargo = request.Cargo,
                DataCriacao = DateTime.Now,
            };
            var resultado = await _userManager.CreateAsync(novoUsuario, request.Senha);
            return resultado;
            
        }
    }
}
