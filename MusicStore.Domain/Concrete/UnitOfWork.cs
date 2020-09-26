using MusicStore.Domain.Concrete;

namespace MusicStore.Domain.Abstract
{
    public class UnitOfWork : IUnitOfWork
    {
        //private readonly DbContext context;
        private readonly ApplicationDbContext context;
        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
           
            Albums = new AlbumRepository(context);
            
            Genres = new GenreRepository(context);
            Carts = new ShoppingRepository(context);
            Cart = new CartRepository(context);
            
                
        }
        public IAlbumRepository Albums
        {
            get; private set;

        }

        public ICartRepository Cart
        {
            get; private set;
        }
        

        public IGenreRepository Genres
        {
            get; private set;
        }

        public IShoppingRepository Carts
        {
            get; private set;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public int Save()
        {
            return context.SaveChanges();
        }
       

    }
}
