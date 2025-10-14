using Microsoft.AspNetCore.Mvc;

namespace Construsys.Controllers
{
    public class MaterialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
