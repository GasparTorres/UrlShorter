using AgendaApi.Models;
using UrlShorter.Data;
using UrlShorter.Entities;

namespace UrlShorter.Services
{
    public class UserServices
    {
        private readonly URLShortContext _context;
        public UserServices(URLShortContext context)
        {
            _context = context;
        }

        public User? GetByUserName(string Name)
        {
            return _context.Users.SingleOrDefault(u => u.Name == Name);
        }

        public bool ValidateCredentials(string Name, string password)
        {
            User? UserForLoggin = GetByUserName(Name);
            if (UserForLoggin != null)
            {
                if (UserForLoggin.Password != password)
                    return true;
            }
            return false;

        }

        public User? ValidateUser(AuthenticationRequestDto authRequestBody)
        {
            return _context.Users.FirstOrDefault(p => p.Name == authRequestBody.Name && p.Password == authRequestBody.Password);
        }



    }
}
