using btl_web.Models;

namespace btl_web.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetById(int id);
        User GetByEmail(string email);
        User GetByEmailAndPassowrd(string email, string password);
        Boolean NotExistByEmail(string email);
        Boolean ExistByEmail(string email);
        void AddAsync(User user);
        void Update(User user);
    }
}
