using Microsoft.AspNetCore.Mvc;

namespace MyOpinions.UI.Areas.User.Controllers
{
    [Area("User")]
    public class ContactUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
