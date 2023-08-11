using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyOpinions.BLL.RepositoryPattern.Base;
using MyOpinions.BLL.RepositoryPattern.Interfaces;
using MyOpinions.DAL.Context;
using MyOpinions.MODEL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MyOpinions.UI.Areas.Management.Controllers
{
    [Area("Management")]
    [Authorize(Policy = "AdminPolicy")]
    public class OpinionsController : Controller
    {

        MyDbContext _db;
		IRepository<Post> _repoPost;
		public OpinionsController(MyDbContext db, IRepository<Post> repoPost)
        {
            _db = db;
			_repoPost = repoPost;
		}
		
		public IActionResult Index()
        {

            List<Post> posts = _db.Posts.Where(x => x.CategoryID == 2 && x.Status != MODEL.Enums.DataStatus.Deleted).ToList();

            return View(posts);

        }
        public IActionResult ReadMore(int id)
        {
            Post post = _repoPost.GetById(id);


			return View(post);
        }


    }
}
