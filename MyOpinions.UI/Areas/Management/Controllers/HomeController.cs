using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyOpinions.BLL.RepositoryPattern.Interfaces;
using MyOpinions.DAL.Context;
using MyOpinions.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyOpinions.UI.Areas.Management.Controllers
{
    [Area("Management")]
    [Authorize(Policy = "AdminPolicy")]


    public class HomeController : Controller
    {
        
		IRepository<Post> _repoPost;
        public HomeController(IRepository<Post> repoPost)
        {
           
            _repoPost = repoPost;
        }
        public IActionResult Index()
        {
            
            List<Post> posts = _repoPost.GetActives();
            
            return View(posts);

        }

        public IActionResult ReadMore(int id)
        {
            Post post = _repoPost.GetById(id);


            return View(post);
        }

        

       
    }
}
