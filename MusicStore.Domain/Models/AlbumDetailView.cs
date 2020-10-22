using MusicStore.Domain.Entities;

namespace MusicStore.Domain.Models
{
    public class AlbumDetailView
    {
        public int AlbumId { get; set; }
        public string ArtistName { get; set; }
        public string GenreName { get; set; }
        public decimal Price { get; set; }
        public string AlbumTitle { get; set; }
        public string AlbumArtUrl { get; set; }
        public Album Album { get; set; }

    }
}