namespace Server.Authentication
{
    public class AuthorizationRequestParameters
    {
        public string ClientId { get; set; }
        public string ResponseType { get; set; }
        public string RedirectUri { get; set; }
        public string State { get; set; }
        public string Scope { get; set; }
        public string ShowDialog { get; set; }
    }
}
