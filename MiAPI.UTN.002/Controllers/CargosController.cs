using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiAPI.UTN._002.Data;
using MiApp.UTN.Modelos;

namespace MiAPI.UTN._002.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargosController : ControllerBase
    {
        private readonly MiAPIUTN_002Context _context;

        public CargosController(MiAPIUTN_002Context context)
        {
            _context = context;
        }

        [HttpGet("EstadisticaCargos")]
        public async Task<ActionResult<IEnumerable<EstadisticaCargos>>> EstadisticaCargos()
        {
            var estadistica = await _context.Cargos
                .Include(c => c.Empleados)
                .Select(c => new EstadisticaCargos
                {
                    Cargo = c.Name,
                    CantidadEmpleados = c.Empleados.Count(),
                    SalarioTotal = c.Empleados.Sum(e => e.Salario + e.Comisiono),
                    SalarioPromedio = c.Empleados.Count() > 0 ?
                        c.Empleados.Average(e => e.Salario + e.Comisiono) : 
                        0
                })
                .ToListAsync();

            return Ok(estadistica);
        }

        // GET: api/Cargos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cargo>>> GetCargo()
        {
            return await _context.Cargos.ToListAsync();
        }

        // GET: api/Cargos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cargo>> GetCargo(int id)
        {
            var cargo = await _context.Cargos.FindAsync(id);

            if (cargo == null)
            {
                return NotFound();
            }

            return cargo;
        }

        // PUT: api/Cargos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCargo(int id, Cargo cargo)
        {
            if (id != cargo.Id)
            {
                return BadRequest();
            }

            _context.Entry(cargo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CargoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cargos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cargo>> PostCargo(Cargo cargo)
        {
            _context.Cargos.Add(cargo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCargo", new { id = cargo.Id }, cargo);
        }

        // DELETE: api/Cargos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargo(int id)
        {
            var cargo = await _context.Cargos.FindAsync(id);
            if (cargo == null)
            {
                return NotFound();
            }

            _context.Cargos.Remove(cargo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CargoExists(int id)
        {
            return _context.Cargos.Any(e => e.Id == id);
        }
    }
}
