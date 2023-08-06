using Microsoft.AspNetCore.Mvc;
using MyOpinions.DAL.Context;
using MyOpinions.MODEL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MyOpinions.UI.Areas.Management.ViewComponents
{
    public class ListPostGadgetViewComponent:ViewComponent
    {
        MyDbContext _db;
        public ListPostGadgetViewComponent(MyDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {

            List<Post> posts = _db.Posts.Where(x => x.Status != MODEL.Enums.DataStatus.Deleted).ToList();

            return View("Gadget", posts);
        }
    }
}
