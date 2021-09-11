using System;

namespace Shared.Authentication
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}
