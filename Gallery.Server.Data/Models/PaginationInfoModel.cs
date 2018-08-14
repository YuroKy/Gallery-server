using System;
using System.Collections.Generic;
using System.Text;

namespace Gallery.Server.Data.Models
{
	public class PaginationInfoModel<T>
	{
		public IEnumerable<T> Data { get; set; }
		public bool IsLast { get; set; }
	}
}
