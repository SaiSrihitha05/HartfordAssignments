using HospitalApiWithDb.Application.DTOs;

namespace HospitalApiWithDb.Application.Interfaces.Services
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentResponseDto>> GetAllAsync();
        Task<AppointmentResponseDto?> GetByIdAsync(int id);
        Task<AppointmentResponseDto> CreateAsync(CreateAppointmentDto dto);
        Task UpdateAsync(int id, UpdateAppointmentDto dto);
        Task DeleteAsync(int id);
    }
}