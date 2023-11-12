using btl_web.Constants;
using btl_web.Models;

namespace btl_web.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }

        public Role Role { get; set; }  

        public UserDto()
        {

        }

        public UserDto(User user)
        {
            if (user == null)
            {
                return;
            }

            Id = user.Id;
            Email = user.Email;
            FullName = user.FullName;
            Description = user.Description;

        }
    }
}
