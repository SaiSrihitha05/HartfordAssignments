using Application.DTOs;

namespace Application.Services
{
    public interface IPatientService
    {
        Task CompleteProfileAsync(int userId, CompletePatientProfileDto dto);
        Task<IEnumerable<PatientResponseDto>> GetAllAsync();
        Task<PatientResponseDto?> GetByIdAsync(int id);
        Task<PatientResponseDto> CreateAsync(CreatePatientDto dto);
        Task UpdateAsync(int id, UpdatePatientDto dto);
        Task DeleteAsync(int id);
        Task<IEnumerable<AppointmentInsidePatientDto>> GetMyAppointmentsAsync(int userId);
        //Task<IEnumerable<AppointmentInsidePatientDto>> GetAppointmentsByPatientAsync(int patientId);
 
    }
}