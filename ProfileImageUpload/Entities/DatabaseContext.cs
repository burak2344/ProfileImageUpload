using Microsoft.EntityFrameworkCore;

namespace ProfileImageUpload.Entities
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<User> Users { get; set; }
	}
}
