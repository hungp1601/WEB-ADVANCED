using System.Linq;
using btl_web.Models;
using Microsoft.EntityFrameworkCore;
using btl_web.Constants.Statuses;
//using btl_web.EF;
using btl_web.Exceptions;
using btl_web.Models;
using BCryptNet = BCrypt.Net.BCrypt;
using btl_web.Repositories.Interfaces;

namespace btl_web.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BtlWebContext _context;

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        public UserRepository(BtlWebContext context)
        {
            _context = context;
        }
        
        public User GetById(int id)
        {
            return _context.Users
                .SingleOrDefault(u => u.Id == id);
        }

        public User GetByEmail(string email)
        {
            return _context.Users
                .SingleOrDefault(u => u.Email == email);
        }

        public User GetByEmailAndPassowrd(string Email, string password)
        {
            User user = _context.Users
                .SingleOrDefault(u => u.Email == Email);
            if (user != null && BCryptNet.Verify(password, user.Password))
            {
                return user;
            }

            return null;
        }

        public void Add(User user)
        {
            if (user == null)
            {
                throw new DataRuntimeException(StatusWrongFormat.USER_IS_NULL);
            }
                
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            if (user == null)
            {
                throw new DataRuntimeException(StatusWrongFormat.USER_IS_NULL);
            }

            _context.Users.Update(user);
            _context.SaveChanges();
        }


        public bool NotExistByEmail(string email)
        {
            return ExistByEmail(email);
        }

        public bool ExistByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new DataRuntimeException(StatusWrongFormat.EMAIL_IS_EMPTY);
            }

            User user = _context.Users.SingleOrDefault(u => u.Email == email);
            if (user == null)
            {
                return false;
            }

            return true;
        }
    }
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

}