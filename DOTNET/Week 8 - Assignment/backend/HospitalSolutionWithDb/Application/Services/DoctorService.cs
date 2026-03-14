using Application.DTOs;
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        public DoctorService(
            IDoctorRepository doctorRepository,
            IAppointmentRepository appointmentRepository)
        {
            _doctorRepository = doctorRepository;
            _appointmentRepository = appointmentRepository;
        }

        public async Task<IEnumerable<DoctorResponseDto>> GetAllAsync()
        {
            var doctors = await _doctorRepository.GetAllAsync();

            return doctors.Select(d => new DoctorResponseDto
            {
                Id = d.Id,
                Name = d.Name,
                Specialization = d.Specialization,
                ExperienceYears = d.ExperienceYears
            });
        }

        public async Task<DoctorResponseDto?> GetByUserIdAsync(int userId)
        {
            var doctor = await _doctorRepository.GetByIdAsync(userId);

            if (doctor == null) return null;

            return new DoctorResponseDto
            {
                Id = doctor.Id,
                Name = doctor.Name,
                Specialization = doctor.Specialization,
                ExperienceYears = doctor.ExperienceYears
            };
        }

        public async Task CompleteProfileAsync(int userId, CompleteDoctorProfileDto dto)
        {
            var doctor = await _doctorRepository.GetByIdAsync(userId);

            if (doctor == null)
            {
                doctor = new Doctor
                {
                    UserId = userId
                };

                await _doctorRepository.AddAsync(doctor);
            }

            doctor.Name = dto.Name;
            doctor.Specialization = dto.Specialization;
            doctor.ExperienceYears = dto.ExperienceYears;
            doctor.IsProfileCompleted = true;

            await _doctorRepository.UpdateAsync(doctor);
        }

        // Application/Services/DoctorService.cs
        public async Task<IEnumerable<AppointmentInsideDoctorDto>> GetMyAppointmentsAsync(int userId)
        {
            // 1. Find the Doctor record using the UserId from the token
            var doctor = await _doctorRepository.GetByIdAsync(userId);
            if (doctor == null) return new List<AppointmentInsideDoctorDto>();

            // 2. Use the DOCTOR'S PRIMARY KEY (doctor.Id) to find appointments
            var appointments = await _appointmentRepository.GetByDoctorIdAsync(doctor.Id);

            return appointments.Select(a => new AppointmentInsideDoctorDto
            {
                Id = a.Id,
                PatientId = a.PatientId,
                DoctorId = a.DoctorId,
                PatientName = a.Patient?.Name ?? "N/A", // Navigation property
                AppointmentDate = a.Date,
                Status = a.Status
            });
        }

        public async Task DeleteAsync(int id)
        {
            await _doctorRepository.DeleteAsync(id);
        }
    }
}