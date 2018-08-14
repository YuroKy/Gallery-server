using System;
using System.Collections.Generic;
using System.Text;

namespace Gallery.Server.Data.Models
{
	public class PaginationModel
	{
		public int Count { get; set; }
		public int? LastItemId { get; set; }
	}
}
