using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Services
{
	public interface IUserManagementService
    {
		Task<IEnumerable<User>> GetAllUsers();
		Task<User> GetUserById(int id);
		Task AddUser(User user);
		Task UpdateUser(User user);
		Task DeleteUser(int id);
	}
}