using System;

namespace Server.Authentication
{
    public class SpotifyToken
    {
        public string Access_Token { get; set; }
        public DateTime Expires_On { get; set; }
        public string Refresh_Token { get; set; }

        private int _expiresIn;
        public int Expires_In
        {
            get => _expiresIn;
            set
            {
                _expiresIn = value;
                Expires_On = DateTime.UtcNow.AddSeconds(value);
            }
        }
    }
}
