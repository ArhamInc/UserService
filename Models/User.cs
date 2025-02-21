using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsersApp.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("first_name")]
        [Required]
        [MaxLength(50)]
        public required string FirstName { get; set; }

        [Column("last_name")]
        [Required]
        [MaxLength(50)]
        public required string LastName { get; set; }

        [Column("email")]
        [Required]
        [MaxLength(100)]
        // unique constraint defined in the UserDbContext
        public required string Email { get; set; }

        [Column("is_active")]
        [Required]
        public bool IsActive { get; set; } = true; // default value = true

        [Column("created_at")]
        [Required]
        public DateTime CreatedAt { get; set; }

        [Column("update_at")]
        [ConcurrencyCheck]
        public DateTime UpdatedAt { get; set; }
    }
}