using Gallery.Server.Data.Models;
using Gallery.Server.Operations.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Gallery.Server.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/Picture")]
	public class PictureController : Controller
	{
		private readonly IPictureOperations _pictureOperations;

		public PictureController(IPictureOperations pictureOperations)
		{
			_pictureOperations = pictureOperations;
		}

		[HttpGet("GetPictures")]
		public IActionResult GetPicturesWithPagination(PaginationModel model)
		{
			if (model.Count == 0)
			{
				model.Count = 20;
			}

			return Ok(_pictureOperations.GetPicturesWithPagination(model));
		}

		[HttpPut("Like")]
		public IActionResult Like(int pictrueId, [FromHeader] int userId)
		{
			_pictureOperations.Like(userId, pictrueId);
			return Ok();
		}
	}
}