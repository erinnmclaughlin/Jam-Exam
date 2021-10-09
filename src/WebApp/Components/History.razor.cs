using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.Components
{
    public partial class History
    {
        [Parameter] public IEnumerable<GuessResultModel> Results { get; set; } = null!;
    }
}
