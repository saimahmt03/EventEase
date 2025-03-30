using System;
using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class User
    {
        public int UserId { get; set; } = 0;

        [Required(ErrorMessage = "Username is required.")]
        [RegularExpression(@"^(?!\d+$)(?![^a-zA-Z0-9]+$).+", ErrorMessage = "The field cannot contain only numbers or special characters.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression(@"^(?!\d+$)(?![^a-zA-Z0-9]+$).+", ErrorMessage = "The field cannot contain only numbers or special characters.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^(?!\d+$)(?![^a-zA-Z0-9]+$).+", ErrorMessage = "The field cannot contain only numbers or special characters.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "First name is required.")]
        [RegularExpression(@"^(?!\d+$)(?![^a-zA-Z0-9]+$).+", ErrorMessage = "The field cannot contain only numbers or special characters.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required.")]
        [RegularExpression(@"^(?!\d+$)(?![^a-zA-Z0-9]+$).+", ErrorMessage = "The field cannot contain only numbers or special characters.")]
        public string LastName { get; set; } = string.Empty;
    }
}