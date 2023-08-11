using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MyOpinions.BLL.RepositoryPattern.Interfaces;
using MyOpinions.DAL.Context;
using MyOpinions.MODEL.Entities;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;


namespace MyOpinions.UI.Areas.User.Controllers
{
	[Area("User")]
	public class AuthController : Controller
	{
		IRepository<AppUser> _repoUser;
		MyDbContext _db;
		public AuthController(MyDbContext db, IRepository<AppUser> repoUser)
		{
			_db = db;
			_repoUser = repoUser;
		}
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]

		public async Task<IActionResult> Login(AppUser user)
		{
			if (_repoUser.any(x => x.UserName == user.UserName && x.Status != MODEL.Enums.DataStatus.Deleted))
			{
				AppUser selectedUser = _repoUser.Default(x => x.UserName == user.UserName && x.Status != MODEL.Enums.DataStatus.Deleted);
				bool isValid = selectedUser.Password == user.Password;
				if (isValid)
				{
					List<Claim> claims = new List<Claim>()
					{
						new Claim("userName",selectedUser.UserName),
						new Claim("userID", selectedUser.ID.ToString()),
						new Claim("role",selectedUser.Role.ToString())
					};
					ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
					ClaimsPrincipal principal = new ClaimsPrincipal(identity);
					await HttpContext.SignInAsync(principal);
					if (selectedUser.Role == MODEL.Enums.Role.admin)
					{
						return RedirectToAction("Index", "Home", new { area = "Management" });
					}
					else if (selectedUser.Role == MODEL.Enums.Role.user)
					{
						return RedirectToAction("Index", "Home", new { area = "User" });
					}
				}
			}
			return View();
		}

		public async Task<IActionResult> LogOut()

		{
			await HttpContext.SignOutAsync();

		
			return RedirectToAction("Index", "Home", new { area = "User" });
		}

		public IActionResult CreateLogin()
		{

			return View();
		}

		[HttpPost]

		public IActionResult CreateLogin(AppUser appUser)
		{
			appUser.Role = MODEL.Enums.Role.user;
			_db.Users.Add(appUser);
			_db.SaveChanges();
			return RedirectToAction("Index", "Home", new { area = "User" });
		}

	}
}
