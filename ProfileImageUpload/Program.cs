using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ProfileImageUpload.Entities;
using ProfileImageUpload.Helpers;
using System.Reflection;

namespace ProfileImageUpload
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

			builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
			builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
			builder.Services.AddDbContext<DatabaseContext>(opts =>
			{
				opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
				//opts.UseLazyLoadingProxies();
			});
			builder.Services
				.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(opts =>
				{
					opts.Cookie.Name = ".ProfileImageUpload.auth";
					opts.ExpireTimeSpan = TimeSpan.FromDays(7);
					opts.SlidingExpiration = false;
					opts.LoginPath = "/Account/Login";
					opts.LogoutPath = "/Account/Logout";
					opts.AccessDeniedPath = "/Home/AccessDenied";
				});
			builder.Services.AddScoped<IHasher, Hasher>();
			//builder.Services.AddScoped<ITokenHelper, TokenHelper>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}