using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Pages
{
    public partial class Index
    {
        [Inject] private HttpClient HttpClient { get; set; }
        private string Message { get; set; } = "Loading...";

        protected override async Task OnInitializedAsync()
        {
            var response = await HttpClient.GetAsync("api/test");
            Message = await response.Content.ReadAsStringAsync();
            await base.OnInitializedAsync();
        }
    }
}
