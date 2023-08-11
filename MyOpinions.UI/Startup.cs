using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyOpinions.BLL.RepositoryPattern.Base;
using MyOpinions.BLL.RepositoryPattern.Interfaces;
using MyOpinions.DAL.Context;
using MyOpinions.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOpinions.UI
{
	public class Startup
	{
		readonly IConfiguration _configuration;
		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;

		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<MyDbContext>(options => options.UseSqlServer(_configuration["ConnectionStrings:Mssql"]));
			services.AddControllersWithViews();
			services.AddScoped<BLL.RepositoryPattern.Interfaces.IRepository<Post>, Repository<Post>>();
			services.AddScoped<BLL.RepositoryPattern.Interfaces.IRepository<AppUser>, Repository<AppUser>>();
			//services.AddScoped<IPhysicsAndOpinionRepository, IPhysicsAndOpinionRepository>();
			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
			{
				options.LoginPath = "/User/Auth/Login";
				options.Cookie.Name = "UserDetail";
				options.AccessDeniedPath = "/User/Auth/Login";
			});
			services.AddAuthorization(options =>
			{
				options.AddPolicy("AdminPolicy", policy => policy.RequireClaim("role", "admin"));


			});


		}


		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MyDbContext context)
		{
			context.Database.Migrate();
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();
			app.UseStaticFiles();
			app.UseAuthentication();
			app.UseAuthorization();



			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
				name: "default",
				pattern: "{area=User}/{controller=Home}/{action=Index}/{id?}");

			});
		}
	}
}
