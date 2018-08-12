namespace Gallery.Server.Data.Models
{
	public class AuthorizationResponseModel
	{
		public int UserId { get; set; }
		public string UserName { get; set; }
		public string AccessToken { get; set; }
	}
}
