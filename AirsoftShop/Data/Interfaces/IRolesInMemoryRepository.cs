using AirsoftShop.Models;

namespace AirsoftShop.Data.Interfaces
{
    public interface IRolesInMemoryRepository
    {
        List<Role> GetAllRoles();
        Role TryGetByRoleName(string name);
        void AddRole(Role role);
        void Delete(string name);
    }
}