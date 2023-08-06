using Microsoft.AspNetCore.Mvc;
using MyOpinions.DAL.Context;
using MyOpinions.MODEL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MyOpinions.UI.Areas.User.ViewComponents
{
    [Area("User")]
    public class SliderListViewComponent:ViewComponent
    {
        MyDbContext _db;
        public SliderListViewComponent(MyDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {

            List<Post> posts = _db.Posts.Where(x => x.Status != MODEL.Enums.DataStatus.Deleted).ToList();

            return View("SliderList", posts);
        }
    }
}
