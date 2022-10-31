﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProfileImageUpload.Models;
using System.Diagnostics;

namespace ProfileImageUpload.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{


		public IActionResult Index()
		{
			return View();
		}
		[AllowAnonymous]
		public IActionResult Privacy()
		{
			return View();
		}
		[AllowAnonymous]
		public IActionResult AccessDenied()
		{
			return View();
		}
		[AllowAnonymous]
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		[HttpGet]
		public IActionResult GetData()
		{
			return Json(new { Name = "BUrak", Surname = "Yünkül" });
		}

		[HttpPost]
		public IActionResult PostData([FromBody] PostDataApiModel model)
		{
			return Json(new { Error = false, Message = "Success" });
		}

	}
}