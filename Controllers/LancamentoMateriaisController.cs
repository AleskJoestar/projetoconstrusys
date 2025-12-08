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
    [Route("Lançamento_Materiais")]
    public class LancamentoMateriaisController : Controller
    {
        private readonly AppDbContext _context;
        public LancamentoMateriaisController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var Materiais = await _context.ConstrucaoMateriais
               .Include(c => c.Construcao)
               .Include(m => m.Material)
               .ToListAsync();
                return Ok(Materiais);
            }
            catch (Exception e)
            {
                return Problem(e.InnerException?.Message ?? e.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ConstrucaoMaterialDto item)
        {
            try
            {

                var construcaoexistente = await _context.Construcoes.FindAsync(item.IdConstrucao);
                if (construcaoexistente == null)
                {
                    return NotFound("Construçao não encontrada.");
                }
                var materialExistente = await _context.Materiais.FindAsync(item.IdMaterial);
                if (materialExistente == null)
                {
                    return NotFound("Material Não Encontrado.");
                }


                var construcaoMaterial = new ConstrucaoMaterial
                {
                    IdConstrucao = item.IdConstrucao,
                    IdMaterial = item.IdMaterial,
                    Quantidade = item.Quantidade

                };
                await _context.ConstrucaoMateriais.AddAsync(construcaoMaterial);
                await _context.SaveChangesAsync();
                return Created("", construcaoMaterial);
            }
            catch (Exception e)
            {
                return Problem(e.InnerException?.Message ?? e.Message);
            }

        }
    }
}

