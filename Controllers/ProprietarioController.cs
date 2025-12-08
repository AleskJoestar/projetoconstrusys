using api_Construsys.DataContexts;
using api_Construsys.Dtos;
using api_Construsys.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace api_Construsys.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Proprietarios")]
    public class ProprietarioController : Controller
    {
        private readonly AppDbContext _context;
        public ProprietarioController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var ListaProprietarios = await _context.Proprietarios.ToListAsync();
                return Ok(ListaProprietarios);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var proprietario = await _context.Proprietarios.Where(s => s.Id == id).FirstOrDefaultAsync();
                if (proprietario == null)
                {
                    return NotFound($"Proprietario #{id} não Encontrado");
                }
                return Ok(proprietario);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProprietarioDto item)
        {
            try
            {
                var proprietario = new Proprietario()
                {
                    Nome = item.Nome,
                    Email = item.Email,

                };
                await _context.Proprietarios.AddAsync(proprietario);
                await _context.SaveChangesAsync();
                return Created("", proprietario);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProprietarioDto item)
        {
            try

            {
                var proprietario = await _context.Proprietarios.FindAsync(id);
                if (proprietario == null)
                {
                    return NotFound();
                }
                proprietario.Nome = item.Nome;
                proprietario.Email = item.Email;
                _context.Proprietarios.Update(proprietario);
                await _context.SaveChangesAsync();
                return Ok(proprietario);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var proprietario = await _context.Proprietarios.FindAsync(id);
                if (proprietario == null)
                {
                    return NotFound();
                }

                _context.Proprietarios.Remove(proprietario);
                await _context.SaveChangesAsync();
                return Ok(proprietario);

            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

    }
}
