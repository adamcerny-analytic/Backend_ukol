using System;
using System.ComponentModel.DataAnnotations;

namespace RequestsAPI.Models
{
    public class AuditLog
    {
        public int Id { get; set; }

        [Required]
        public string EntityName { get; set; } = string.Empty; 

        public int EntityId { get; set; } // ID záznamu v tabulce Requests

        [Required]
        public string Action { get; set; } = string.Empty; // Create / Update / Delete

        public string OldValue { get; set; } = string.Empty; // JSON starých dat
        public string NewValue { get; set; } = string.Empty; // JSON nových dat

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
