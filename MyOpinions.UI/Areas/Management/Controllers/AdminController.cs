using Microsoft.AspNetCore.Mvc;
using MyOpinions.DAL.Context;
using MyOpinions.MODEL.Entities;
using System.IO;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace MyOpinions.UI.Areas.Management.Controllers
{
    [Area("Management")]
    [Authorize(Policy ="AdminPolicy")]

    public class AdminController : Controller
    {
        MyDbContext _db;
        public AdminController(MyDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            

            return View();

        }  


        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]

        public IActionResult CreateCategory(Category category)
        {

            _db.Categories.Add(category);
            _db.SaveChanges();
            return RedirectToAction("Index", "Admin", new { area = "Management" });
        }

        public IActionResult CreatePost()
        {

            List<Category> categories = _db.Categories.Where(x => x.Status != MODEL.Enums.DataStatus.Deleted).Select(x=> 
            new Category
            {
                CategoryName = x.CategoryName,
                ID = x.ID,


            }).ToList();
            

            return View((new Post(), categories));
        }
        [HttpPost]
        public IActionResult CreatePost([Bind(Prefix ="Item1")] Post newPost)
        {
            
            if (newPost.Dosya != null)
            {
                string kokDizin = Directory.GetCurrentDirectory();
                string kayitDizini = Path.Combine(kokDizin, "wwwroot", "images");
                string dosyaAdi = Guid.NewGuid() + Path.GetExtension(newPost.Dosya.FileName);
                string tamYol = Path.Combine(kayitDizini, dosyaAdi);

                using (var dosyaAkisi = new FileStream(tamYol, FileMode.Create))
                {
                    newPost.Dosya.CopyTo(dosyaAkisi);
                }

                newPost.PictureName = dosyaAdi;
                
            }

            _db.Posts.Add(newPost);
            _db.SaveChanges();

            return RedirectToAction("Index", "Admin", new {area="Management"} );
        }

        //public IActionResult Edit(int id)
        //{
        //    Post post = _db.Posts.Find(id);
        //    Category categories = _db.Categories.Find(id);  
            
        //    ViewBag.Category = categories;
        //    return View(post);
        //}

        //[HttpPost]
        //public IActionResult Edit(Post post)
        //{
        //    post.Status = MODEL.Enums.DataStatus.Updated;
        //    post.ModifiedDate = DateTime.Now;
        //    _db.Posts.Update(post);
        //    _db.SaveChanges();
        //    return RedirectToAction("Index", "Home", new { area = "Management" });
        //}

        public IActionResult Delete(int id)
        {
            Post post = _db.Posts.Find(id);
            post.Status = MODEL.Enums.DataStatus.Deleted;
            post.ModifiedDate = DateTime.Now;
            _db.Posts.Update(post);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home", new { area = "Management" });

        }



    }
}

