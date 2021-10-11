using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public class TimeZoneService
    {
        private readonly IJSRuntime _js; 
        private int? _userOffset;

        public TimeZoneService(IJSRuntime js)
        {
            _js = js;
        }

        public async ValueTask<DateTime> ToLocalTime(DateTime utc)
        {
            _userOffset ??= await _js.InvokeAsync<int>("getTimezoneOffset");
            return utc.AddMinutes(0 - _userOffset.Value);
        }
    }
}
