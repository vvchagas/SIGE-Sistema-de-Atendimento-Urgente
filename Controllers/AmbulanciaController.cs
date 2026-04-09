using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using SIGEApi.DTOs.AmbulanciaDtos;
using SIGEApi.DTOs.AuthDtos;
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

    }
}
