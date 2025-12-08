using api_Construsys.DataContexts;
using ApiServico.Models;
using BCrypt.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiServico.Controllers
{
    [Authorize]
    [Route("usuarios")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] UsuarioRegistroDto dto)
        {
            var usuario = new Usuario
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Perfil = dto.Perfil,
                Senha = BCrypt.Net.BCrypt.HashPassword(dto.Senha)
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return Ok("Usuário registrado com sucesso!");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var usuarios = await _context.Usuarios
                    .Select(u => new
                    {
                        u.Id,
                        u.Nome,
                        u.Email,
                        u.Perfil
                        // Senha não é retornada
                    })
                    .ToListAsync();

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var usuario = await _context.Usuarios
                    .Where(u => u.Id == id)
                    .Select(u => new
                    {
                        u.Id,
                        u.Nome,
                        u.Email,
                        u.Perfil
                    })
                    .FirstOrDefaultAsync();

                if (usuario == null)
                    return NotFound($"Usuário com ID {id} não encontrado.");

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);

                if (usuario == null)
                    return NotFound($"Usuário com ID {id} não encontrado.");

                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();

                return Ok($"Usuário com ID {id} removido com sucesso!");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }



    }
}
