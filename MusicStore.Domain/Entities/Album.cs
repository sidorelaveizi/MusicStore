using System.ComponentModel.DataAnnotations;

namespace MusicStore.Domain.Entities
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }
        public int GenreId { get; set; }
        public int ArtistId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        public decimal Price { get; set; }
        [Required]
        public string AlbumArtUrl { get; set; }
        public Genre Genre { get; set; }
       
        public Artist Artist { get; set; }
    }
}
