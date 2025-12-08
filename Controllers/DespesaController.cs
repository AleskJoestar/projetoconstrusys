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
    [Route("Despesas")]
    public class DespesaController : Controller
    {
        private readonly AppDbContext _context;
        public DespesaController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var despesas = await _context.Despesas
            .ToListAsync();
                return Ok(despesas);
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
                var despesas = await _context.Despesas.Where(s => s.Id == id).FirstOrDefaultAsync();
                if (despesas == null)
                {
                    return NotFound($"Despesa #{id} não Encontrada");
                }
                return Ok(despesas);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DespesaDto item)
        {
            try
            {

                var construcaoExistente = await _context.Construcoes.FindAsync(item.IdConstrucao);
                if (construcaoExistente == null)
                {
                    return NotFound("Construção não encontrada.");
                }
                var fornecedorExistente = await _context.Fornecedores.FindAsync(item.IdFornecedor);
                if (fornecedorExistente == null)
                {
                    return NotFound("Fornecedor não encontrado.");
                }
                var despesas = new Despesa()
                {
                    Descricao = item.Descricao,
                    valor = item.Valor,
                    data = item.Data,
                    IdConstrucao = item.IdConstrucao,
                    IdFornecedor = item.IdFornecedor,

                };
                await _context.Despesas.AddAsync(despesas);
                await _context.SaveChangesAsync();
                return Created("", despesas);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DespesaDto item)
        {
            try

            {
                var construcaoExistente = await _context.Construcoes.FindAsync(item.IdConstrucao);
                if (construcaoExistente == null)
                {
                    return NotFound("Construção não encontrada.");
                }
                var fornecedorExistente = await _context.Fornecedores.FindAsync(item.IdFornecedor);
                if (fornecedorExistente == null)
                {
                    return NotFound("Fornecedor não encontrado.");
                }
                var DespesaAtual = await _context.Despesas.FindAsync(id);
                if (DespesaAtual == null)
                {
                    return NotFound();
                }
                {
                    DespesaAtual.Descricao = item.Descricao;
                    DespesaAtual.valor = item.Valor;
                    DespesaAtual.IdConstrucao = item.IdConstrucao;
                    DespesaAtual.IdFornecedor = item.IdFornecedor;

                }
                ;

                _context.Despesas.Update(DespesaAtual);
                await _context.SaveChangesAsync();
                return Ok(DespesaAtual);
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

                var despesaAtual = await _context.Despesas.FindAsync(id);
                if (despesaAtual == null)
                {
                    return NotFound();
                }

                _context.Despesas.Remove(despesaAtual);
                await _context.SaveChangesAsync();
                return Ok($"A Despesa com ID {id} foi removida com sucesso.");

            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }


    }
}