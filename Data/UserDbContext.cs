using Microsoft.EntityFrameworkCore;
using UsersApp.Models;

namespace UsersApp.Data {
	public class UserDbContext : DbContext {
		public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

		public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(mb => mb.Email)
                .IsUnique();
        }
    }
}