using Microsoft.AspNetCore.Mvc;

namespace Campeonato.Client.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Teams");
        }
    }
}