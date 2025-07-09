using AirsoftShop.Data.Interfaces;
using AirsoftShop.Models;

namespace AirsoftShop.Data.Repositories
{
    public class RolesInMemoryRepository : IRolesInMemoryRepository
    {
        private readonly List<Role> _roles = new List<Role>();

        public List<Role> GetAllRoles()
        {
            return _roles;
        }

        public Role TryGetByRoleName(string name)
        {
            return _roles.FirstOrDefault(x => x.Name == name);
        }
        public void AddRole(Role role)
        {
            _roles.Add(role);
        }
        public void Delete(string name)
        {
            _roles.RemoveAll(x => x.Name == name);
        }
    }
}
