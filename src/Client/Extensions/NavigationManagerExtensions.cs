using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;

namespace Client.Extensions
{
    public static class NavigationManagerExtensions
    {
        public static string TryGetQueryString(this NavigationManager navManager, string key)
        {
            var uri = navManager.ToAbsoluteUri(navManager.Uri);
            var qs = QueryHelpers.ParseQuery(uri.Query);

            return qs.TryGetValue(key, out var val) ? val : string.Empty;
        }
    }
}
