using System;

namespace WebApp.Components
{
    public partial class History : IDisposable
    {
        public void Dispose()
        {
            GameService.PropertyChanged -= (o, e) => StateHasChanged();
            GC.SuppressFinalize(this);
        }

        protected override void OnInitialized()
        {
            GameService.PropertyChanged += (o, e) => StateHasChanged();
            base.OnInitialized();
        }
    }
}
