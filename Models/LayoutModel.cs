using btl_web.Dtos;

namespace btl_web.Models
{
    public abstract class ViewModelBase
    {
        public UserDto user { get; set; }
    }

    public class HomeViewModel : ViewModelBase
    {
    }
}
