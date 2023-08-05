using Microsoft.EntityFrameworkCore;
using MyOpinions.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOpinions.DAL.Context
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }


        public DbSet<AppUser> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<Category> Categories { get; set; }







    }
}
