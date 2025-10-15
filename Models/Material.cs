using Microsoft.AspNetCore.Mvc;

namespace Construsys.Models
{
    public class Material : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
