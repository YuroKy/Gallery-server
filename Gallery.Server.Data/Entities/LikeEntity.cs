namespace Gallery.Server.Data.Entities
{
	public class LikeEntity
	{
		public int Id { get; set; }
		public UserEntity User { get; set; }
		public PictureEntity Picture { get; set; }
	}
}
