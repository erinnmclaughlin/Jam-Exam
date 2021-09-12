namespace Server.Models
{
    public class SpotifySearchResultsModel
    {
        public PagedResponseModel<SpotifyArtistModel> Artists { get; set; }
    }
}
