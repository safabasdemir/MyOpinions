using Microsoft.EntityFrameworkCore;
using MyOpinions.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOpinions.DAL.Initializer
{
    public static class DataInitializer
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser() {ID=1, UserName="admin",Password="123",Role=MODEL.Enums.Role.admin },
                new AppUser() {ID=2, UserName="safa",Password="1234",Role=MODEL.Enums.Role.user }
                );
        }
    }
}
