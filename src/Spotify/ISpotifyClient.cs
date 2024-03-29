﻿using Refit;
using Spotify.Models;
using Spotify.Requests;
using Spotify.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spotify
{
    public interface ISpotifyClient
    {
        [Get("/albums/{albumId}")]
        Task<ApiResponse<Album>> GetAlbumById(string albumId);

        [Get("/artists")]
        Task<ApiResponse<ArtistList>> GetArtists(IEnumerable<string> ids);

        [Get("/playlists/{playlistId}")]
        Task<ApiResponse<Playlist>> GetPlaylistById(string playlistId);

        [Get("/playlists/{playlistId}/tracks")]
        Task<ApiResponse<PagedResponse<PlaylistTrack>>> GetPlaylistTracks(string playlistId);

        [Get("/search")]
        Task<ApiResponse<SearchResponse>> Search(SearchRequest request);
    }
}
