using api_Construsys.DataContexts;
using api_Construsys.Dtos;
using api_Construsys.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_Construsys.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Construções")]
    public class ConstrucaoController : Controller
    {
        private readonly AppDbContext _context;
        public ConstrucaoController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var construcoes = await _context.Construcoes
            .Include(c => c.Proprietario)
            .Select(c => new ConstrucaoResponseDto
            {
                Id = c.Id,
                Nome = c.Nome,
                Localização = c.localizacao,
                Proprietario = new ProprietarioResponseDto
                {
                    Nome = c.Proprietario.Nome

                }
            })
            .ToListAsync();
                return Ok(construcoes);
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
                var construcoes = await _context.Construcoes.Where(s => s.Id == id)
               .Include(c => c.Proprietario)
               .Select(c => new ConstrucaoResponseDto
               {
                   Id = c.Id,
                   Nome = c.Nome,
                   Localização = c.localizacao,
                   Proprietario = new ProprietarioResponseDto
                   {
                       Nome = c.Proprietario.Nome

                   }
               })
               .FirstOrDefaultAsync();
                if (construcoes == null)
                {
                    return NotFound($"Construção #{id} não Encontrada");
                }
                return Ok(construcoes);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ConstrucaoDto item)
        {
            try
            {
                // Verifica se o proprietário com o ID fornecido existe
                var proprietarioExistente = await _context.Proprietarios.FindAsync(item.IdProprietario);
                if (proprietarioExistente == null)
                {
                    return NotFound("Proprietário não encontrado.");
                }
                var construcao = new Construcao()
                {
                    Nome = item.Nome,
                    localizacao = item.Localizacao,
                    IdProprietario = item.IdProprietario

                };
                await _context.Construcoes.AddAsync(construcao);
                await _context.SaveChangesAsync();
                var response = new ConstrucaoResponseDto
                {
                    Id = construcao.Id,
                    Nome = construcao.Nome,
                    Localização = construcao.localizacao,
                    Proprietario = new ProprietarioResponseDto
                    {
                        Nome = proprietarioExistente.Nome,

                    }
                };
                return Created("", response);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ConstrucaoDto item)
        {
            try

            {

                var proprietarioExistente = await _context.Proprietarios.FindAsync(item.IdProprietario);
                if (proprietarioExistente == null)
                {
                    return NotFound("Proprietário não encontrado.");
                }
                var ConstrucaoAtual = await _context.Construcoes.FindAsync(id);
                if (ConstrucaoAtual == null)
                {
                    return NotFound();
                }
                ConstrucaoAtual.Nome = item.Nome;
                ConstrucaoAtual.localizacao = item.Localizacao;
                ConstrucaoAtual.IdProprietario = item.IdProprietario;



                _context.Construcoes.Update(ConstrucaoAtual);
                await _context.SaveChangesAsync();
                var response = new ConstrucaoResponseDto
                {
                    Id = ConstrucaoAtual.Id,
                    Nome = ConstrucaoAtual.Nome,
                    Localização = ConstrucaoAtual.localizacao,
                    Proprietario = new ProprietarioResponseDto
                    {
                        Nome = proprietarioExistente.Nome,

                    }

                };
                return Ok(response);
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

                var construcaoAtual = await _context.Construcoes.FindAsync(id);
                if (construcaoAtual == null)
                {
                    return NotFound($"Construção {id} Não Encontrada");
                }

                _context.Construcoes.Remove(construcaoAtual);
                await _context.SaveChangesAsync();
                return Ok($"Construção com ID {id} foi removida com sucesso.");

            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
