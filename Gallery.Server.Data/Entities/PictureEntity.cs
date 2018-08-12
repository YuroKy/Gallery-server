using System;
using System.Collections.Generic;
using System.Text;

namespace Gallery.Server.Data.Entities
{
	public class PictureEntity
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public UserEntity Author { get; set; }
		public string Path { get; set; }
		public int LikeCount { get; set; }
		public List<CommentEntity> Comments { get; set; }
	}
}
