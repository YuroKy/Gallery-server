using Microsoft.EntityFrameworkCore;
using Gallery.Server.Data.Entities;

namespace Gallery.Server.Data
{
	public class ApplicationContext:DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options){}

		public DbSet<PictureEntity> Pictures { get; set; }
		public DbSet<UserEntity> Users { get; set; }
		public DbSet<CommentEntity> Comments { get; set; }


	}
}
