using System.Collections.Generic;
using System.Threading.Tasks;
using UsersApp.Models;

namespace UsersApp.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User?> GetUserById(int id);
        Task<User> SaveOrUpdateUser(User user);
    }
}