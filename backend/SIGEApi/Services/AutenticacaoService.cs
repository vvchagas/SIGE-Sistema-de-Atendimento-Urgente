using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SIGEApi.Data;
using SIGEApi.DTOs.AuthDtos;
using SIGEApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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

        public async Task<IdentityResult> Registrar(RegisterRequestDto request)
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
        public async Task<AutenticacaoRespostaDto> Logar(LoginRequestDto request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, request.Senha))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email!),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                authClaims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    expires: DateTime.Now.AddMinutes(double.Parse(_configuration["Jwt:ExpiryMinutes"]!)),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)),
                    SecurityAlgorithms.HmacSha256
                    )
                    );
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenString = tokenHandler.WriteToken(token);
                return new AutenticacaoRespostaDto
                {
                    Sucesso = true,
                    Token = tokenString,
                    Nome = user.Nome,
                    Cargo = user.Cargo,
                    Roles = userRoles,
                    Mensagem = "Usuário logado com sucesso"                    
                };
            }
            return new AutenticacaoRespostaDto
            {
                Sucesso = false,
                Mensagem = "E-mail ou senha inválidos",
            };
        }
        public async Task<AutenticacaoRespostaDto> GarantirUserRole(UserRole request)
        {
            var roleExiste = await _roleManager.RoleExistsAsync(request.Role);
            if (!roleExiste) { return new AutenticacaoRespostaDto { Sucesso = false, Mensagem = "Role não existe no Banco de Dados" }; }
            
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null) { return new AutenticacaoRespostaDto { Sucesso = false, Mensagem = "Usuário não encontrado" }; }

            var rolesUsuario = await _userManager.GetRolesAsync(user);
            if (rolesUsuario.Contains("Admin")) { return new AutenticacaoRespostaDto { Sucesso = false, Mensagem = $"O usuário já possui a role {request.Role}", Roles = rolesUsuario,  }; }

            var resultado = await _userManager.AddToRoleAsync(user, request.Role);

            if (resultado.Succeeded)
            {
                return new AutenticacaoRespostaDto
                {
                    Sucesso = true,
                    Nome = user.Nome,
                    Cargo = user.Cargo,
                    Roles = rolesUsuario,
                    Mensagem = "Role garantida com sucesso"
                };
            }
            return new AutenticacaoRespostaDto()
            {
                Sucesso = false,
                Mensagem = resultado.Errors.ToString()!
            };

        }
    }
}
