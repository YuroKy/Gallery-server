using System;
using System.Collections.Generic;
using System.Text;

namespace Gallery.Server.Data.Entities
{
	public class Picture
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public User Author { get; set; }
		public string Path { get; set; }
		public int LikeCount { get; set; }
		public List<Comment> Comments { get; set; }
	}
}
