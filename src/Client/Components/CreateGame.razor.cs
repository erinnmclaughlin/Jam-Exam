using Client.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using Refit;
using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Components
{
    public partial class CreateGame
    {
        [Inject] private IJamApi Api { get; set; }

        [Parameter] public string GenreId { get; set; }
        [Parameter] public EventCallback<List<TrackModel>> OnCreate { get; set; }

        private CreateGameModel CreateGameModel { get; set; } = new();

        private async Task HandleValidSubmit()
        {
            var response = await Api.CreateGame(GenreId, CreateGameModel);

            if (response.IsSuccessStatusCode)
                await OnCreate.InvokeAsync(response.Content);
        }
    }
}
