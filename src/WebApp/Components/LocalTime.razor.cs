using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using WebApp.Services;

namespace WebApp.Components
{
    public partial class LocalTime
    {
        [Inject] private TimeZoneService TimeZoneService { get; set; } = null!;
        [Parameter] public DateTime UtcTime { get; set; }

        private DateTime? Local { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                var local = await TimeZoneService.ToLocalTime(UtcTime);
               
                StateHasChanged();
            }
        }
    }
}
