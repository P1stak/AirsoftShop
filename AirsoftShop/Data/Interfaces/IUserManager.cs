using AirsoftShop.Models;

namespace AirsoftShop.Data.Interfaces
{
    public interface IUserManager
    {
        void Add(UserAccount userAccount);
        void ChangePassword(string userName, string newPassword);
        List<UserAccount> GetAll();
        UserAccount TryGetByName(string name);
    }
}