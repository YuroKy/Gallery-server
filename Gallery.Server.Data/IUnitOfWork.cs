using System.Threading.Tasks;
using Gallery.Server.Data.Abstractions;
using Gallery.Server.Data.Entities;

namespace Gallery.Server.Data
{
	public interface IUnitOfWork
	{
		IRepository<UserEntity> UsersRepository { get; }
		IRepository<CommentEntity> CommentsRepository { get; }
		IRepository<PictureEntity> PicturesRepository { get; }
		IRepository<LikeEntity> LikesRepository { get; }
		void SaveChanges();
		Task SaveChangesAsync();
	}
}
