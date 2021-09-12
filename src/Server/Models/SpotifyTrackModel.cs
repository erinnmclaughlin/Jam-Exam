namespace Server.Models
{
    public class SpotifyTrackModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Preview_Url { get; set; }
        public SpotifyArtistModel[] Artists { get; set; }
    }
}
