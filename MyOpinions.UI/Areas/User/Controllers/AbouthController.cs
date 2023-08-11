using Microsoft.AspNetCore.Mvc;

namespace MyOpinions.UI.Areas.User.Controllers
{
    [Area("User")]
    public class AbouthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
