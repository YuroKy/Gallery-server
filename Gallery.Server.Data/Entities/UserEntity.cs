using Gallery.Server.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gallery.Server.Data.Entities
{
	public class UserEntity
    {
		public int Id { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public List<PictureEntity> Pictures { get; set; }
		public Roles Role { get; set; }
	}
}
