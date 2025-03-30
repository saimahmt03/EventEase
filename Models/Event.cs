using System;
using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class Event
    {
        public int EventId { get; set; } = 0;

        [Required(ErrorMessage = "Event name is required.")]
        [RegularExpression(@"^(?!\d+$)(?![^a-zA-Z0-9]+$).+", ErrorMessage = "The field cannot contain only numbers or special characters.")]
        public string EventName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Event description is required.")]
        [RegularExpression(@"^(?!\d+$)(?![^a-zA-Z0-9]+$).+", ErrorMessage = "The field cannot contain only numbers or special characters.")]
        public string EventDescription { get; set; } = string.Empty;

        [Required(ErrorMessage = "Event location is required.")]
        [RegularExpression(@"^(?!\d+$)(?![^a-zA-Z0-9]+$).+", ErrorMessage = "The field cannot contain only numbers or special characters.")]
        public string EventLocation { get; set; } = string.Empty;

        [Required(ErrorMessage = "Event datetime is required.")]
        [RegularExpression(@"^(?!\d+$)(?![^a-zA-Z0-9]+$).+", ErrorMessage = "The field cannot contain only numbers or special characters.")]
        public string EventDateTime { get; set; } = string.Empty;

        [Required(ErrorMessage = "Event duration is required.")]
        [RegularExpression(@"^(?!\d+$)(?![^a-zA-Z0-9]+$).+", ErrorMessage = "The field cannot contain only numbers or special characters.")]
        public string EventDuration { get; set; } = string.Empty;

        [Required(ErrorMessage = "Event organizer is required.")]
        [RegularExpression(@"^(?!\d+$)(?![^a-zA-Z0-9]+$).+", ErrorMessage = "The field cannot contain only numbers or special characters.")]
        public string EventOrganizer { get; set; } = string.Empty;
    }
}