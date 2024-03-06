using Microsoft.AspNetCore.Mvc;

namespace Minnie_ReadingPost.Controllers
{
    public class _Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
