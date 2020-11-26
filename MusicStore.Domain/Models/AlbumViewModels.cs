using MusicStore.Domain.Entities;
using System.Collections.Generic;

namespace MusicStore.Domain.Models
{
    public class AlbumViewModels 
    {
        public IEnumerable<Album> Albums { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public string GenreName { get; set; }

    }
}