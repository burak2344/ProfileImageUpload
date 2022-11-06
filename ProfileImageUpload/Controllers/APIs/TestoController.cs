using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfileImageUpload.Helpers;
using ProfileImageUpload.Models;

namespace ProfileImageUpload.Controllers.APIs
{
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	[Route("api/[controller]")]
	[ApiController]
	public class TestoController : ControllerBase
	{

		private readonly ITokenHelper _tokenHelper;

		public TestoController(ITokenHelper tokenHelper)
		{
			_tokenHelper = tokenHelper;
		}

		[HttpGet("get-data")]
		public IActionResult GetData()
		{
			return Ok(new { Name = "Burak", Surname = "Yünkül" });
		}

		[HttpPost("add")]
		public IActionResult PostData([FromBody] PostDataApiModel model)
		{
			return Ok(model);
		}

		[AllowAnonymous]
		[HttpPost("login")]
		public IActionResult Login([FromBody] LoginViewModel model)
		{
			if (model.Username == "aaa" && model.Password == "123")
			{
				string token = _tokenHelper.GenerateToken(model.Username, 0);

				return Ok(new { Error = false, Message = "Token created.", Data = token });
			}
			else
			{
				return BadRequest(new { Error = true, Message = "Incorrect identity." });
			}
		}
	}
}
