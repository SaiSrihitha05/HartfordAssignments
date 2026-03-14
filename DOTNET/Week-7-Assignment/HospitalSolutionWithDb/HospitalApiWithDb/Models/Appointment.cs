namespace HospitalApiWithDb.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } = "Scheduled";

        // Foreign Key
        public int DoctorId { get; set; }

        // Navigation
        public Doctor? Doctor { get; set; }
    }
}