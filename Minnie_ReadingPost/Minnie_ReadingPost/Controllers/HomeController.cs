using Microsoft.AspNetCore.Mvc;

namespace Minnie_ReadingPost.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
