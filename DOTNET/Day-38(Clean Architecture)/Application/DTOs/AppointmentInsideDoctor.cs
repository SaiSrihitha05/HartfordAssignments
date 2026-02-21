namespace HospitalApiWithDb.Application.DTOs
{
    public class AppointmentInsideDoctorDto
    {
        public int Id { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}