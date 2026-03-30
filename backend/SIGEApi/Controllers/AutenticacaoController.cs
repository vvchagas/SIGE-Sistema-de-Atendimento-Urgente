using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using SIGEApi.DTOs.AuthDtos;
using SIGEApi.Models;
using SIGEApi.Services;
using System.Linq.Expressions;

namespace SIGEApi.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AutenticacaoController(AutenticacaoService serivce) : ControllerBase
    {
        [HttpPost("registrar")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {

            var resultado = await serivce.Registrar(request);

            if (resultado.Succeeded)
            {
                return Ok(new { message = "Usuario registrado com sucesso" });
            }
            return BadRequest(resultado.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Logar(LoginRequestDto request)
        {
            var respostaRequest = await serivce.Logar(request);

            if (respostaRequest.Sucesso) { return Ok(respostaRequest); }
            else { return BadRequest(respostaRequest); }
        }

        [Authorize]
        [HttpPost("assign-role")]
        public async Task<IActionResult> DesignarRole(UserRole request)
        {
            var respostaRequest = await serivce.GarantirUserRole(request);

            if (respostaRequest.Sucesso) { return Ok(respostaRequest); }
            return BadRequest(respostaRequest);
        }
    }
}
