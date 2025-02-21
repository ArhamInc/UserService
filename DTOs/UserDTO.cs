using System.ComponentModel.DataAnnotations;

namespace UsersApp.DTOs
{
    public class UserDTO
    {
        public int? Id { get; set; } // Nullable to allow for creation without specifying an ID
        
        [Required(ErrorMessage = "First name is required")]
        [MaxLength(50, ErrorMessage = "First name can't be longer than 50 characters")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(50, ErrorMessage = "Last name can't be longer than 50 characters")]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "Email is requried")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public required string Email { get; set; }

    }
}
