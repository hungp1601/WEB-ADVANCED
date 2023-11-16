using btl_web.Dtos;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace btl_web.Services.Interfaces
{
    public interface IUserService
    {
        UserDto Login(string username, string password);
        UserDto GetUserById(int id);
        UserDto GetUserByEmail(string email);
        UserDto Register(UserDto dto);
        bool Logout();

        public void saveUserToSession(UserDto user);

        public void removeUserFromSession();

        public UserDto getUserFromSession();
        
    }
}
