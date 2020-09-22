using MusicStore.Domain.Entities;
using System.Collections.Generic;

namespace MusicStore.WebUI.Models
{
    public class AlbumViewModels 
    {

       public Album Albums { get; set; }
       public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<Artist> Artists { get; set; }
       public string SearchString { get; set; }

    }
}