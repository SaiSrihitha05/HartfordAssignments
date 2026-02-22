using Application.DTOs;

namespace Application.Services
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorResponseDto>> GetAllAsync();

        Task<DoctorResponseDto?> GetByUserIdAsync(int userId);
        Task CompleteProfileAsync(int userId, CompleteDoctorProfileDto dto);
        Task<IEnumerable<AppointmentInsideDoctorDto>> GetMyAppointmentsAsync(int userId);

        Task DeleteAsync(int id);
    }
}