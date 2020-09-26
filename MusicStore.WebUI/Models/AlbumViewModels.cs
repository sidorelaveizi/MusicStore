using MusicStore.Domain.Entities;
using System.Collections.Generic;

namespace MusicStore.WebUI.Models
{
    public class AlbumViewModels 
    {
        
       public Album Albums { get; set; }
       public IEnumerable<Genre> Genres { get; set; }
        public Artist Artists { get; set; }

        public Genre Genre { get; set; }
      

    }
}