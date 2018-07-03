using Microsoft.EntityFrameworkCore;
using Gallery.Server.Data.Entities;

namespace Gallery.Server.Data
{
	public class ApplicationContext:DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options){}

		public DbSet<Picture> Pictures { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Comment> Comments { get; set; }


	}
}
