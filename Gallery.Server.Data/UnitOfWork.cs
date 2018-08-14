using Gallery.Server.Data.Abstractions;
using Gallery.Server.Data.Entities;
using Gallery.Server.Data.Implementation;
using System.Threading.Tasks;

namespace Gallery.Server.Data
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationContext _context;
		public IRepository<UserEntity> UsersRepository { get; }
		public IRepository<CommentEntity> CommentsRepository { get; }
		public IRepository<PictureEntity> PicturesRepository { get; }
		public IRepository<LikeEntity> LikesRepository { get; }


		public UnitOfWork(ApplicationContext context)
		{
			_context = context;
			UsersRepository = new Repository<UserEntity>(context);
			CommentsRepository = new Repository<CommentEntity>(context);
			PicturesRepository = new Repository<PictureEntity>(context);
			LikesRepository = new Repository<LikeEntity>(context);
		}

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}
	}
}