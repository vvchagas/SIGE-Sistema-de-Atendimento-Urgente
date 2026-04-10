using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using SIGEApi.DTOs.AmbulanciaDtos;
using SIGEApi.DTOs.AuthDtos;
using SIGEApi.Enums;
using SIGEApi.Models;
using SIGEApi.Services;
using System.Linq.Expressions;
using System.Security.Claims;
namespace SIGEApi.Controllers
{
    [Authorize]
    [Route("ambulancias")]
    [ApiController]
    public class AmbulanciaController(AmbulanciaService service) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Ambulancia>> CriarAmbulancia(AmbulanciaCreateDTO ambulancia)
        {
            try
            {
                var novaAmbulancia = await service.CreateAmbulancia(ambulancia);
                return CreatedAtAction(nameof(CriarAmbulancia), new { id = novaAmbulancia.Id }, novaAmbulancia);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<Ambulancia>>> ListarTodasAmbulancias(int pagina, int quantidade)
        {
            try
            {
                var ambulancias = await service.Listar(pagina, quantidade);
                return Ok(ambulancias);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpDelete]
        public async Task<ActionResult> DeletarAmbulancia(Guid id)
        {
            try
            {
                await service.DeletarAmbulancia(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Ambulancia>> GetAmbulanciaById(Guid id)
        {
            try
            {
                var ambulancia = await service.GetAmbulanciaById(id);
                return Ok(ambulancia);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Ambulancia>> AtualizarAmbulancia(Guid id, AmbulanciaUpdateDTO ambulancia)
        {
            try
            {
                var ambulanciaAtualizada = await service.AtualizarAmbulancia(id, ambulancia);
                return Ok(ambulanciaAtualizada);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPatch("{id}/status")]
        public async Task<ActionResult<Ambulancia>> AtualizarStatusAmbulancia(Guid id, StatusAmbulancia status)
        {
            try
            {
                var ambulanciaAtualizada = await service.AtualizarStatusAmbulancia(id, status);
                return Ok(ambulanciaAtualizada);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
