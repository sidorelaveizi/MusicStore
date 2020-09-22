using System.Collections.Generic;

namespace MusicStore.Domain.Entities
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<Album> Albums { get; set; }
    }
}
