using System.ComponentModel.DataAnnotations;

namespace MovReminder.Models
{
    public class UserModel
    {
        [Required, MaxLength(50)]
        public string Username { get; set; } = null!;

        [Required, MaxLength(20)]
        public string Password { get; set; } = null!;

        [Required, MaxLength(100)]
        public string Email { get; set; } = null!;
    }
}
