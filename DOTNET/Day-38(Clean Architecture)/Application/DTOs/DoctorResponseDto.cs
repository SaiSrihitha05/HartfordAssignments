namespace HospitalApiWithDb.Application.DTOs
{
    public class DoctorResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public int ExperienceYears { get; set; }

        public List<AppointmentInsideDoctorDto> Appointments { get; set; } = new List<AppointmentInsideDoctorDto>();
    }
}
