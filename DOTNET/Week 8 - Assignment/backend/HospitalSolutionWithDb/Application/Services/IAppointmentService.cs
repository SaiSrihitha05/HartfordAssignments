using Application.DTOs;

namespace Application.Services
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentResponseDto>> GetAllAsync();
        Task<AppointmentResponseDto?> GetByIdAsync(int id);
        Task<AppointmentResponseDto> CreateAsync(int userId,CreateAppointmentDto dto);
        Task UpdateAsync(int id, UpdateAppointmentDto dto);
        Task DeleteAsync(int id);
        Task<IEnumerable<AppointmentInsideDoctorDto>> GetByDoctorAsync(int doctorId);
        Task<IEnumerable<AppointmentResponseDto>> GetByPatientAsync(int patientId);
    }
}