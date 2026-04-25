using Autos.Api.Data;
using Autos.Api.Models;
using Autos.Api.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Autos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutosController : ControllerBase
    {

        private readonly AppDbContext _context;

        public AutosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/autos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutoResponseDto>>> GetAutos()
        {
            var autos = await _context.Autos.ToListAsync();
            return Ok(autos.Select(MapToResponse));
        }


        // GET: api/autos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<AutoResponseDto>> GetAuto(int id)
        {
            var auto = await _context.Autos.FindAsync(id);

            if (auto == null)
                return NotFound();

            return Ok(MapToResponse(auto));
        }

        // POST: api/autos (crear un nuevo auto)
        [HttpPost]
        public async Task<ActionResult<AutoResponseDto>> CreateAuto(AutoCreateDto dto)
        {
            if (dto.Anio < 1885 || dto.Anio > DateTime.Now.Year + 1)
            {
                return BadRequest("El año debe estar entre 1885 y el próximo año.");
            }

            var auto = new Auto
            {
                Marca = dto.Marca,
                Modelo = dto.Modelo,
                Anio = dto.Anio,
                TipoDeAuto = dto.TipoDeAuto,
                CantidadDeAsientos = dto.CantidadDeAsientos,
                Color = dto.Color,
                TieneAireAcondicionado = dto.TieneAireAcondicionado,
                TipoCombustible = dto.TipoCombustible
            };

            _context.Autos.Add(auto);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return BadRequest("Error al guardar en la base de datos");
            }

            return CreatedAtAction(nameof(GetAuto),
                new { id = auto.Id },
                MapToResponse(auto));
        }


        // PUT: api/autos/{id} (actualizar auto existente)
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuto(int id, AutoUpdateDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("El ID de la URL no coincide con el ID del body.");
            }

            if (dto.Anio < 1885 || dto.Anio > DateTime.Now.Year + 1)
            {
                return BadRequest("El año debe estar entre 1885 y el próximo año.");
            }

            var auto = await _context.Autos.FindAsync(id);

            if (auto == null)
            {
                return NotFound();
            }

            auto.Marca = dto.Marca;
            auto.Modelo = dto.Modelo;
            auto.Anio = dto.Anio;
            auto.TipoDeAuto = dto.TipoDeAuto;
            auto.CantidadDeAsientos = dto.CantidadDeAsientos;
            auto.Color = dto.Color;
            auto.TieneAireAcondicionado = dto.TieneAireAcondicionado;
            auto.TipoCombustible = dto.TipoCombustible;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return BadRequest("Error al actualizar en la base de datos.");
            }

            return NoContent();
        }


        // DELETE: api/autos/{id}
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteAuto(int id)
        {
            var auto = await _context.Autos.FindAsync(id);

            if (auto == null)
            {
                return NotFound();
            }

            _context.Autos.Remove(auto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private static AutoResponseDto MapToResponse(Auto auto)
        {
            return new AutoResponseDto
            {
                Id = auto.Id,
                Marca = auto.Marca,
                Modelo = auto.Modelo,
                Anio = auto.Anio,
                TipoDeAuto = auto.TipoDeAuto,
                CantidadDeAsientos = auto.CantidadDeAsientos,
                Color = auto.Color,
                TieneAireAcondicionado = auto.TieneAireAcondicionado,
                TipoCombustible = auto.TipoCombustible
            };
        }

    }
}
