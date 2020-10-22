using MusicStore.Domain.Entities;
using System.Collections.Generic;

namespace MusicStore.Domain.Models
{
    public class AlbumViewModels 
    {
        //public Album Albums { get; set; }
        public IEnumerable<Album> Albums { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        //public Artist Artists { get; set; }
        //public IEnumerable<Artist> Artist { get; set; }
        //public Genre TakeGenres { get; set; }

        public string GenreName { get; set; }

    }
}