using System;

namespace Auth.Domain.Entities
{
    public class UserAccount
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = "Resident"; // Resident or Admin
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
