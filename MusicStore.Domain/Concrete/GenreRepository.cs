using MusicStore.Domain.Concrete;
using MusicStore.Domain.Entities;

namespace MusicStore.Domain.Abstract
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        private readonly ApplicationDbContext _context;
        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }
       
    }
}
