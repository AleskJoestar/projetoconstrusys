using api_Construsys.Controllers;
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
    [Route("Fornecedores")]
    public class FornecedorController : Controller

    {
        private readonly AppDbContext _context;
        public FornecedorController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var ListaFornecedores = await _context.Fornecedores.ToListAsync();
                return Ok(ListaFornecedores);
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
                var fornecedor = await _context.Fornecedores.Where(s => s.Id == id).FirstOrDefaultAsync();
                if (fornecedor == null)
                {
                    return NotFound($"Fornecedor #{id} não Encontrado");
                }
                return Ok(fornecedor);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FornecedorDto item)
        {
            try
            {
                var fornecedor = new Fornecedor()
                {
                    Nome = item.Nome,
                    Contato = item.Contato,

                };
                await _context.Fornecedores.AddAsync(fornecedor);
                await _context.SaveChangesAsync();
                return Created("", fornecedor);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FornecedorDto item)
        {
            try
            {

                var fornecedor = await _context.Fornecedores.FindAsync(id);
                if (fornecedor == null)
                {
                    return NotFound("Fornecedor não encontrado.");
                }


                fornecedor.Nome = item.Nome;
                fornecedor.Contato = item.Contato;

                _context.Fornecedores.Update(fornecedor);
                await _context.SaveChangesAsync();

                return Ok(fornecedor);
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
                var fornecedor = await _context.Fornecedores.FindAsync(id);
                if (fornecedor == null)
                {
                    return NotFound();
                }

                _context.Fornecedores.Remove(fornecedor);
                await _context.SaveChangesAsync();
                return Ok(fornecedor);

            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

    }
}

