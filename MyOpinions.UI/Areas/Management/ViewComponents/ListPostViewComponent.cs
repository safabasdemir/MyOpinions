﻿using Microsoft.AspNetCore.Mvc;
using MyOpinions.DAL.Context;
using MyOpinions.MODEL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MyOpinions.UI.Areas.Management.ViewComponents
{
    [Area("Management")]
    public class ListPostViewComponent : ViewComponent
    {
        MyDbContext _db;
        public ListPostViewComponent(MyDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {

            List<Post> posts = _db.Posts.Where(x => x.Status != MODEL.Enums.DataStatus.Deleted).ToList();

            return View("Slider",posts);
        }

    }
}
