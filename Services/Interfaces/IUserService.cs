using btl_web.Dtos;

namespace btl_web.Services.Interfaces
{
    public interface IUserService
    {
        UserDto Login(string username, string password);
        UserDto GetUserById(int id);
        UserDto GetUserByEmail(string email);
        UserDto Register(UserDto dto);
    }
}
