namespace HospitalApiWithDb.Application.DTOs
{
    public class CreateAppointmentDto
    {
        public string PatientName { get; set; } = string.Empty;
        public DateTime AppointmentDate { get; set; }
        public int DoctorId { get; set; }
    }
}