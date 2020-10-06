using MusicStore.Domain.Entities;
using System.Web.Mvc;

namespace MusicStore.WebUI.Models
{
    public class GenreViewModel
    {
        public Album Album { get; set; }
        public int SelectGenreId { get; set; }
        public SelectList Genres { get; set; }

    }
}