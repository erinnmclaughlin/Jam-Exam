using System;
using System.Text;

namespace Spotify.Extensions;

internal static class StringExtensions
{
    public static string EncodeBase64(this string text) =>
        Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
}
