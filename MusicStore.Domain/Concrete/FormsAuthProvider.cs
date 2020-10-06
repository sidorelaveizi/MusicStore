using MusicStore.Domain.Abstract;
using System.Web.Security;

namespace MusicStore.Domain.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        private readonly ApplicationDbContext _context;
        public FormsAuthProvider(ApplicationDbContext context)
        {
            _context = context;

        }
        public bool Authenticate(string username, string password)
        {
            bool result = Membership.ValidateUser(username, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }
            return result;
        }
    }
    }
