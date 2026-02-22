using Application.DTOs;
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repository;
        private readonly IAppointmentRepository _appointmentRepository;

        public PatientService(
            IPatientRepository repository,
            IAppointmentRepository appointmentRepository)
        {
            _repository = repository;
            _appointmentRepository = appointmentRepository;
        }
        public async Task CompleteProfileAsync(int userId, CompletePatientProfileDto dto)
        {
            var patient = await _repository.GetByUserIdAsync(userId);

            if (patient == null)
            {
                patient = new Patient
                {
                    UserId = userId,
                    Name = dto.Name,
                    Age = dto.Age,
                    Gender = dto.Gender,
                    Phone = dto.Phone,
                    IsProfileCompleted = true
                };

                await _repository.AddAsync(patient);
            }
            else
            {
                patient.Name = dto.Name;
                patient.Age = dto.Age;
                patient.Gender = dto.Gender;
                patient.Phone = dto.Phone;
                patient.IsProfileCompleted = true;

                await _repository.UpdateAsync(patient);
            }
        }
        public async Task<IEnumerable<PatientResponseDto>> GetAllAsync()
        {
            var patients = await _repository.GetAllAsync();

            return patients.Select(p => new PatientResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Age = p.Age,
                Gender = p.Gender,
                Phone = p.Phone
            });
        }

        public async Task<PatientResponseDto?> GetByIdAsync(int id)
        {
            var patient = await _repository.GetByIdAsync(id);
            if (patient == null) return null;

            return new PatientResponseDto
            {
                Id = patient.Id,
                Name = patient.Name,
                Age = patient.Age,
                Gender = patient.Gender,
                Phone = patient.Phone
            };
        }

        public async Task<PatientResponseDto> CreateAsync(CreatePatientDto dto)
        {
            var patient = new Patient
            {
                UserId = dto.UserId,
                Name = dto.Name,
                Age = dto.Age,
                Gender = dto.Gender,
                Phone = dto.Phone
            };

            await _repository.AddAsync(patient);

            return new PatientResponseDto
            {
                Id = patient.Id,
                Name = patient.Name,
                Age = patient.Age,
                Gender = patient.Gender,
                Phone = patient.Phone
            };
        }

        public async Task UpdateAsync(int id, UpdatePatientDto dto)
        {
            var patient = await _repository.GetByIdAsync(id);
            if (patient == null)
                throw new Exception("Patient not found");

            patient.Name = dto.Name;
            patient.Age = dto.Age;
            patient.Gender = dto.Gender;
            patient.Phone = dto.Phone;

            await _repository.UpdateAsync(patient);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<AppointmentInsidePatientDto>>
    GetMyAppointmentsAsync(int userId)
        {
            var patient = await _repository.GetByUserIdAsync(userId);

            if (patient == null)
                throw new Exception("Profile not completed");

            var appointments = await _appointmentRepository
                .GetByPatientIdAsync(patient.Id);

            return appointments.Select(a => new AppointmentInsidePatientDto
            {
                Id = a.Id,
                DoctorName = a.Doctor?.Name ?? "",
                AppointmentDate = a.Date,
                Status = a.Status
            });
        }
    }
}