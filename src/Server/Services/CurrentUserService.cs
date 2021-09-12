using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Server.Services
{
    public class CurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            Token = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Authentication);
            Claims = httpContextAccessor.HttpContext?.User?.Claims.AsEnumerable().Select(item => new KeyValuePair<string, string>(item.Type, item.Value)).ToList();
        }

        public string UserId { get; }
        public string Token { get; set; }
        public List<KeyValuePair<string, string>> Claims { get; set; }
    }
}
