using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using SIGEApi.DTOs.AuthDtos;
using SIGEApi.Models;
using SIGEApi.Services;

namespace SIGEApi.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AutenticacaoController(AutenticacaoService serivce) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {

            var resultado = await serivce.Registrar(request);

            if (resultado.Succeeded)
            {
                return Ok(new { message = "Usuario registrado com sucesso" });
            }
            return BadRequest(resultado.Errors);
        }
    }

    
}
