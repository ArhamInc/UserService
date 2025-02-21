using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UsersApp.Models;
using UsersApp.Data;

namespace UsersApp.Repositories {
    public class UserRepository : IUserRepository {

        private readonly UserDbContext context;

        public UserRepository(UserDbContext context) {
            this.context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsers() {
            return await context.Users.Where(u => u.IsActive).ToListAsync();
        }

        public async Task<User?> GetUserById(int id) {
            return await context.Users.FirstOrDefaultAsync(u => u.Id == id && u.IsActive);
        }

        public async Task<User> SaveOrUpdateUser(User user) {
            // creating a new user
            if (user.Id == 0) {
                context.Users.Add(user);
            }
            // updating existing user
            else {
                context.Entry(user).State = EntityState.Modified;
            }
            await context.SaveChangesAsync();
            return user;
        }
    }
}