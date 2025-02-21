using AutoMapper;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Threading.Tasks;
using UsersApp.Models;
using UsersApp.DTOs;
using UsersApp.Repositories;
using UsersApp.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace UsersApp.Services {
    public class UserService : IUserService {

        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper) {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsers() {
            var users = await userRepository.GetAllUsers();
            return mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO> GetUserById(int id) {
            var user = await userRepository.GetUserById(id);
            if (user == null) {
                throw new UserNotFoundException($"User with id: {id} not found");
            }
            return mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> AddUser(UserDTO userRequest) {
            try {
                var user = mapper.Map<User>(userRequest);
                user.CreatedAt = DateTime.Now;
                user.UpdatedAt = DateTime.Now;
                var createdUser = await userRepository.SaveOrUpdateUser(user);
                return mapper.Map<UserDTO>(createdUser);
            }
            catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("Cannot insert duplicate key") == true) {
                throw new InvalidOperationException($"A user with email: {userRequest.Email} already exists");
            }
        }

        public async Task<UserDTO> UpdateUser(int id, UserDTO userRequest) {
            try {
                var exisitingUser = await userRepository.GetUserById(id);
                if (exisitingUser == null) {
                    throw new UserNotFoundException($"User with id: {id} not found");
                }
                var user = mapper.Map<User>(userRequest);
                user.Id = exisitingUser.Id;
                user.CreatedAt = exisitingUser.CreatedAt;
                user.UpdatedAt = DateTime.Now;
                var updatedUser = await userRepository.SaveOrUpdateUser(user);
                return mapper.Map<UserDTO>(updatedUser);
            }
            catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("Cannot insert duplicate key") == true) {
                throw new InvalidOperationException($"A user with email: {userRequest.Email} already exists");
            }
        }   

        public async Task DeleteUser(int id) {
            var user = await userRepository.GetUserById(id);
            if (user == null) {
                throw new UserNotFoundException($"User with id: {id} not found");
            }
            user.IsActive = true;
            await userRepository.SaveOrUpdateUser(user);
        }

    }
}
