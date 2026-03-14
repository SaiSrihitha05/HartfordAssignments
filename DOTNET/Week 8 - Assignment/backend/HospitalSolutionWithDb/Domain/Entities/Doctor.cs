namespace Domain.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public int ExperienceYears { get; set; }

        // Navigation Property
        public List<Appointment>? Appointments { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public bool IsProfileCompleted { get; set; } = false;
    }
}