namespace Server.Authentication
{
    public class SpotifyTokenResponse
    {
        public string Access_Token { get; set; }
        public int Expires_In { get; set; }
        public string Refresh_Token { get; set; }
    }
}
