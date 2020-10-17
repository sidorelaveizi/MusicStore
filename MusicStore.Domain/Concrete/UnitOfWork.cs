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
            Cart = new CartRepository(context);
            Artists = new ArtistRepository(context);
            //Users = new UserRepository(context);
            Orders = new OrderRepository(context);
            OrdersDetails = new OrderDetailsRepository(context);
        }
        public IAlbumRepository Albums
        {
            get; private set;

        }

        public IArtistRepository Artists
        {
            get; private set;

        }

        public ICartRepository Cart
        {
            get; private set;
        }

        //public IUserRepository Users
        //{
        //    get; private set;
        //}
        
        public IOrderInterface Orders
        {
            get; private set;
        }
        public IOrderDetailsRepository OrdersDetails
        {
            get; private set;
        }
        public IGenreRepository Genres
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
