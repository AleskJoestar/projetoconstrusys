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
    [Route("Lançamentos de mao de obra")]
    public class LancamentoMaoDeObraController : Controller
    {
        private readonly AppDbContext _context;
        public LancamentoMaoDeObraController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var maoDeObra = await _context.Mao_De_Obras.Include(mo => mo.Construcao)

            .ToListAsync();
                return Ok(maoDeObra);
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
                var maoDeObra = await _context.Mao_De_Obras.Where(s => s.Id == id).Include(mo => mo.Construcao).FirstOrDefaultAsync();
                if (maoDeObra == null)
                {
                    return NotFound($"Mão de Obra #{id} não Encontrada");
                }
                return Ok(maoDeObra);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MaoDeObraDto item)
        {
            try
            {

                var ConstrucaoExistente = await _context.Proprietarios.FindAsync(item.IdConstrucao);
                if (ConstrucaoExistente == null)
                {
                    return NotFound("Construção não encontrada.");
                }
                var maodeObra = new MaoDeObra()
                {
                    Descricao = item.descricao,
                    custo = item.custo,
                    IdConstrucao = item.IdConstrucao

                };
                await _context.Mao_De_Obras.AddAsync(maodeObra);
                await _context.SaveChangesAsync();
                return Created("", maodeObra);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] MaoDeObraDto item)
        {
            try

            {

                var ConstrucaoExistente = await _context.Proprietarios.FindAsync(item.IdConstrucao);
                if (ConstrucaoExistente == null)
                {
                    return NotFound("Construção não encontrada.");
                }
                var maoDeObra = await _context.Mao_De_Obras.FindAsync(id);
                if (maoDeObra == null)
                {
                    return NotFound();
                }
                maoDeObra.Descricao = item.descricao;
                maoDeObra.custo = item.custo;
                maoDeObra.IdConstrucao = item.IdConstrucao;



                _context.Mao_De_Obras.Update(maoDeObra);
                await _context.SaveChangesAsync();
                return Ok(maoDeObra);
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

                var maoDeObra = await _context.Mao_De_Obras.FindAsync(id);
                if (maoDeObra == null)
                {
                    return NotFound();
                }

                _context.Mao_De_Obras.Remove(maoDeObra);
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

