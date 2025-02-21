using System.Collections.Generic;
using System.Threading.Tasks;
using UsersApp.DTOs;
using UsersApp.Models;

namespace UsersApp.Services
{
    public interface IUserService
    {
		Task<IEnumerable<UserDTO>> GetAllUsers();
		Task<UserDTO> GetUserById(int id);
		Task<UserDTO> AddUser(UserDTO userRequest);
		Task<UserDTO> UpdateUser(int id, UserDTO userRequest);
		Task DeleteUser(int id);
	}
}