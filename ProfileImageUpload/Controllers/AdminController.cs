using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ProfileImageUpload.Controllers
{
	public class AdminController : Controller
	{
		//[Authorize(Roles = "admin,manager")]
		[Authorize(Roles = "admin")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
