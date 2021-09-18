namespace Server.Models
{
    public class SpotifyUserModel
    {
        public string Display_Name { get; set; }
        public string Id { get; set; }
        public SpotifyImageModel[] Images { get; set; }
    }
}
