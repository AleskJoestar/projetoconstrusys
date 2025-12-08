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
    [Route("Materiais")]
    public class MaterialController : Controller

    {
        private readonly AppDbContext _context;
        public MaterialController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var materiais = await _context.Materiais
            .ToListAsync();
                return Ok(materiais);
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
                var materiais = await _context.Materiais.Where(s => s.Id == id).FirstOrDefaultAsync();
                if (materiais == null)
                {
                    return NotFound($"Material #{id} não Encontrada");
                }
                return Ok(materiais);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MaterialDto item)
        {
            try
            {


                var materiais = new Material()
                {
                    Nome = item.Nome,
                    Unidade = item.Unidade,

                };
                await _context.Materiais.AddAsync(materiais);
                await _context.SaveChangesAsync();
                return Created("", materiais);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] MaterialDto item)
        {
            try

            {

                var materiais = await _context.Materiais.FindAsync(id);
                if (materiais == null)
                {
                    return NotFound();
                }
                {
                    materiais.Nome = item.Nome;
                    materiais.Unidade = item.Unidade;

                }
                ;

                _context.Materiais.Update(materiais);
                await _context.SaveChangesAsync();
                return Ok(materiais);
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

                var materiais = await _context.Materiais.FindAsync(id);
                if (materiais == null)
                {
                    return NotFound();
                }

                _context.Materiais.Remove(materiais);
                await _context.SaveChangesAsync();
                return Ok($"O Material {materiais.Nome} com ID {id} foi removido com sucesso.");

            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

    }
}

