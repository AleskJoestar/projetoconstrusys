using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiServico.Controllers
{
    [Route("teste")]
    [ApiController]
    public class TesteController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Autenticado com sucesso 😎");
        }
    }
}
