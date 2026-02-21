using HospitalApiWithDb.Application.DTOs;
using HospitalApiWithDb.Application.Interfaces.Repositories;
using HospitalApiWithDb.Application.Interfaces.Services;
using HospitalApiWithDb.Domain.Entities;

namespace HospitalApiWithDb.Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _repository;

        public DoctorService(IDoctorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<DoctorResponseDto>> GetAllAsync()
        {
            var doctors = await _repository.GetAllAsync();

            return doctors.Select(d => new DoctorResponseDto
            {
                Id = d.Id,
                Name = d.Name,
                Specialization = d.Specialization,
                ExperienceYears = d.ExperienceYears,
                Appointments = d.Appointments?
                    .Select(a => new AppointmentInsideDoctorDto
                    {
                        Id = a.Id,
                        PatientName = a.PatientName,
                        AppointmentDate = a.AppointmentDate,
                        Status = a.Status
                    }).ToList() ?? new List<AppointmentInsideDoctorDto>()
            });
        }

        public async Task<DoctorResponseDto?> GetByIdAsync(int id)
        {
            var doctor = await _repository.GetByIdAsync(id);
            if (doctor == null) return null;

            return new DoctorResponseDto
            {
                Id = doctor.Id,
                Name = doctor.Name,
                Specialization = doctor.Specialization,
                ExperienceYears = doctor.ExperienceYears,
                Appointments = doctor.Appointments?
                    .Select(a => new AppointmentInsideDoctorDto
                    {
                        Id = a.Id,
                        PatientName = a.PatientName,
                        AppointmentDate = a.AppointmentDate,
                        Status = a.Status
                    }).ToList() ?? new List<AppointmentInsideDoctorDto>()
            };
        }

        public async Task<DoctorResponseDto> CreateAsync(CreateDoctorDto dto)
        {
            var doctor = new Doctor
            {
                Name = dto.Name,
                Specialization = dto.Specialization,
                ExperienceYears = dto.ExperienceYears
            };

            await _repository.AddAsync(doctor);

            return new DoctorResponseDto
            {
                Id = doctor.Id,
                Name = doctor.Name,
                Specialization = doctor.Specialization,
                ExperienceYears = doctor.ExperienceYears
            };
        }

        public async Task UpdateAsync(int id, UpdateDoctorDto dto)
        {
            var doctor = await _repository.GetByIdAsync(id);
            if (doctor == null) throw new Exception("Doctor not found");

            doctor.Name = dto.Name;
            doctor.Specialization = dto.Specialization;
            doctor.ExperienceYears = dto.ExperienceYears;

            await _repository.UpdateAsync(doctor);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}