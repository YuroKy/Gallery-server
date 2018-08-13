using Gallery.Server.Data.Abstractions;
using Gallery.Server.Data.Entities;
using Gallery.Server.Data.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gallery.Server.Data
{
	public class UnitOfWork : IDisposable
	{
		private readonly ApplicationContext _context;
		private readonly IRepository<UserEntity> _userRepository;
		private readonly IRepository<CommentEntity> _commentRepository;
		private readonly IRepository<PictureEntity> _pictureRepository;

		public UnitOfWork(ApplicationContext context)
		{
			_context = context;
			_userRepository = new Repository<UserEntity>(context);
			_commentRepository = new Repository<CommentEntity>(context);
			_pictureRepository = new Repository<PictureEntity>(context);
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
