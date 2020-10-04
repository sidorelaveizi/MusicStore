using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;

namespace MusicStore.Domain.Concrete
{
    public class ArtistRepository : GenericRepository<Artist>, IArtistRepository
    {
        private readonly ApplicationDbContext _context;
        public ArtistRepository(ApplicationDbContext context)
        {
            _context = context;

        }
    }
}
