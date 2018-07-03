﻿using Gallery.Server.Data.Enums;
using System;

namespace Gallery.Server.Data.Entities
{
	public class Comment
	{
		public int Id { get; set; }
		public User Author { get; set; }
		public DateTime Date { get; set; }
		public string Content { get; set; }
		public CommentStatus Status { get; set; }
	}
}