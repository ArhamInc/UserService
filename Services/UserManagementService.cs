using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Threading.Tasks;
using UserService.Models;
using UserService.Repositories;

namespace UserService.Services
{
    public class UserManagementService : IUserManagementService
    {
        private readonly IUserRepository userRepository;

        public UserManagementService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await userRepository.GetAllUsers();
        }

        public async Task<User> GetUserById(int id)
        {
            return await userRepository.GetUserById(id);
        }

        public async Task AddUser(User user)
        {
            await userRepository.AddUser(user);
        }

        public async Task UpdateUser(User user)
        {
            await userRepository.UpdateUser(user);
        }   

        public async Task DeleteUser(int id)
        {
            await userRepository.DeleteUser(id);
        }

    }
}
