using Microsoft.AspNetCore.Mvc;

namespace Construsys.Controllers
{
    public class DespesasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
