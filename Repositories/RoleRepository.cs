using btl_web.Models;
using btl_web.Repositories.Interfaces;

namespace btl_web.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly BtlWebContext _context;

        public RoleRepository(BtlWebContext context)
        {
            _context = context;
        }

        public Role GetByName(string name)
        {
            return _context.Roles.SingleOrDefault(u => u.Name.Equals(name));
        }
    }
}
