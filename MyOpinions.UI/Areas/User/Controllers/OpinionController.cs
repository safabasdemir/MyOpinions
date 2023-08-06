﻿using Microsoft.AspNetCore.Mvc;
using MyOpinions.DAL.Context;
using MyOpinions.MODEL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MyOpinions.UI.Areas.User.Controllers
{
    [Area("User")]
    public class OpinionController : Controller
    {
        MyDbContext _db;
        public OpinionController(MyDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            List<Post> posts = _db.Posts.Where(x => x.CategoryID == 2 && x.Status != MODEL.Enums.DataStatus.Deleted).ToList();

            return View(posts);

        }
        public IActionResult ReadMore(int id)
        {
            var deger = _db.Posts.Where(x => x.ID == id).ToList();
            return View(deger);
        }
    }
    
}
