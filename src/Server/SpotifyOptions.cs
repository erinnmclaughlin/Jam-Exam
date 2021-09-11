namespace Server
{
    public class SpotifyOptions
    {
        public const string ResponseType = "code";
        public const string Scope = "user-read-private";

        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectUri { get; set; }
    }
}
