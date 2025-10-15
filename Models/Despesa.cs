using Microsoft.AspNetCore.Mvc;

namespace Construsys.Models
{
    public class Despesa : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
