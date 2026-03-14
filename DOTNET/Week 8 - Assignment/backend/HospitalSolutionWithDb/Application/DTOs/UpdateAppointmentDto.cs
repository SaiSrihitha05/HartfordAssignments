namespace Application.DTOs
{
    public class UpdateAppointmentDto
    {
            public int DoctorId { get; set; }
            public int PatientId { get; set; }
            public DateTime AppointmentDate { get; set; }
            public string Status { get; set; } = string.Empty;
    }
    
}