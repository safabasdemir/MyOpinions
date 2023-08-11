using Microsoft.AspNetCore.Mvc;
using MyOpinions.DAL.Context;
using MyOpinions.MODEL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MyOpinions.UI.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {

        MyDbContext _db;
        public HomeController(MyDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            List<Post> posts = _db.Posts.Where(x => x.Status != MODEL.Enums.DataStatus.Deleted).ToList();

            return View(posts);

        }

        public IActionResult ReadMore(int id)
        {
            Post post = _db.Posts.Find(id);


            return View(post);
        }
    }
}
