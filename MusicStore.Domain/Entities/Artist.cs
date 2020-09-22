using System.ComponentModel.DataAnnotations;

namespace MusicStore.Domain.Entities
{
    public class Artist
    {
        public int ArtistId { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
