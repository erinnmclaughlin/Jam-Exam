namespace WebApp.Components
{
    public partial class History : IDisposable
    {
        public void Dispose()
        {
            GameService.PropertyChanged -= async (o, e) => await InvokeAsync(StateHasChanged);
            GC.SuppressFinalize(this);
        }

        protected override void OnInitialized()
        {
            GameService.PropertyChanged += async (o, e) => await InvokeAsync(StateHasChanged);
            base.OnInitialized();
        }
    }
}
