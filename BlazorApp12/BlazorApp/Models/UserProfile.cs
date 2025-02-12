using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class UserProfile
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Range(18, 120, ErrorMessage = "Age must be between 18 and 120")]
        public int Age { get; set; }
    }
}