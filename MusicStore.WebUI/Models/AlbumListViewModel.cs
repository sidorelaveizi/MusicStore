using MusicStore.Domain.Entities;
using System.Collections.Generic;

namespace MusicStore.WebUI.Models
{
    public class AlbumListViewModel
    {
        public List<Album> Albums { get; set; }
        public int CurrentPageIndex { get; set; }
        public int PageCount { get; set; }
    }
}