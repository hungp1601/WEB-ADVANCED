using btl_web.Models;

namespace btl_web.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Role GetByName(string name);
    }
}
