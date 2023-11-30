using Microsoft.AspNetCore.Mvc;

namespace Vacunacion.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult MenuSuperAdmin()
        {
            return View("MenuSuperAdmin");
        }

        public IActionResult MenuAdmin()
        {
            return View("MenuAdmin");
        }
    }
}
