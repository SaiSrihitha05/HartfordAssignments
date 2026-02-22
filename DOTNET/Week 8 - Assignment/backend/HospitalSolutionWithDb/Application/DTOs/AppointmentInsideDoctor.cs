namespace Application.DTOs
{
    public class AppointmentInsideDoctorDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; } // Add this
        public int DoctorId { get; set; }  // Add this
        public string PatientName { get; set; } = string.Empty;
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}