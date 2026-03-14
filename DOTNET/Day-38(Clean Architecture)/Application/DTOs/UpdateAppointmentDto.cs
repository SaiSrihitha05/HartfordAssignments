namespace HospitalApiWithDb.Application.DTOs
{
    public class UpdateAppointmentDto
    {
        public string PatientName { get; set; } = string.Empty;
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public int DoctorId { get; set; }
    }
}