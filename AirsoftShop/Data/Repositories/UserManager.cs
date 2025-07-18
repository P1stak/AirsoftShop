using AirsoftShop.Data.Interfaces;
using AirsoftShop.Models;

namespace AirsoftShop.Data.Repositories
{
    public class UserManager : IUserManager
    {
        private readonly List<UserAccount> _users = new List<UserAccount>();

        public List<UserAccount> GetAll()
        {
            return _users;
        }
        public void Add(UserAccount userAccount)
        {
            _users.Add(userAccount);
        }
        public UserAccount TryGetByName(string name)
        {
            return _users.FirstOrDefault(x => x.UserFullName == name);
        }

        public void ChangePassword(string userName, string newPassword)
        {
            var account = TryGetByName(userName);
            if (account != null)
            {
                account.Password = newPassword;
            }
        }

        public void Delete(string userName)
        {
            var user = _users.FirstOrDefault(x => x.UserFullName == userName);
            _users.Remove(user);
        }
    }
}
