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
		public string FileName { get; set; }
		public List<LikeEntity> Likes { get; set; }
		public List<CommentEntity> Comments { get; set; }
		public DateTime UploadDate { get; set; }
	}
}