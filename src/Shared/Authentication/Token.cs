using System;

namespace Shared.Authentication
{
    public class Token
    {
        public DateTime Expiry { get; set; }
        public string Value { get; set; }
    }
}
