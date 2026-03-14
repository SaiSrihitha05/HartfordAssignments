using HospitalApiWithDb.Application.DTOs;

namespace HospitalApiWithDb.Application.Interfaces.Services
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorResponseDto>> GetAllAsync();
        Task<DoctorResponseDto?> GetByIdAsync(int id);
        Task<DoctorResponseDto> CreateAsync(CreateDoctorDto dto);
        Task UpdateAsync(int id, UpdateDoctorDto dto);
        Task DeleteAsync(int id);
    }
}