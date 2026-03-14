using HospitalApiWithDb.Application.DTOs;
using HospitalApiWithDb.Application.Interfaces.Repositories;
using HospitalApiWithDb.Application.Interfaces.Services;
using HospitalApiWithDb.Domain.Entities;

namespace HospitalApiWithDb.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repository;
        private readonly IDoctorRepository _doctorRepository;

        public AppointmentService(
            IAppointmentRepository repository,
            IDoctorRepository doctorRepository)
        {
            _repository = repository;
            _doctorRepository = doctorRepository;
        }

        public async Task<IEnumerable<AppointmentResponseDto>> GetAllAsync()
        {
            var appointments = await _repository.GetAllAsync();

            return appointments.Select(a => new AppointmentResponseDto
            {
                Id = a.Id,
                PatientName = a.PatientName,
                AppointmentDate = a.AppointmentDate,
                Status = a.Status,
                DoctorId = a.DoctorId,
                DoctorName = a.Doctor?.Name ?? ""
            });
        }

        public async Task<AppointmentResponseDto?> GetByIdAsync(int id)
        {
            var appointment = await _repository.GetByIdAsync(id);
            if (appointment == null) return null;

            return new AppointmentResponseDto
            {
                Id = appointment.Id,
                PatientName = appointment.PatientName,
                AppointmentDate = appointment.AppointmentDate,
                Status = appointment.Status,
                DoctorId = appointment.DoctorId,
                DoctorName = appointment.Doctor?.Name ?? ""
            };
        }

        public async Task<AppointmentResponseDto> CreateAsync(CreateAppointmentDto dto)
        {
            var appointment = new Appointment
            {
                PatientName = dto.PatientName,
                AppointmentDate = dto.AppointmentDate,
                DoctorId = dto.DoctorId,
                Status = "Scheduled"
            };

            await _repository.AddAsync(appointment);

            return new AppointmentResponseDto
            {
                Id = appointment.Id,
                PatientName = appointment.PatientName,
                AppointmentDate = appointment.AppointmentDate,
                Status = appointment.Status,
                DoctorId = appointment.DoctorId
            };
        }

        public async Task UpdateAsync(int id, UpdateAppointmentDto dto)
        {
            var appointment = await _repository.GetByIdAsync(id);
            if (appointment == null) throw new Exception("Appointment not found");

            appointment.PatientName = dto.PatientName;
            appointment.AppointmentDate = dto.AppointmentDate;
            appointment.Status = dto.Status;
            appointment.DoctorId = dto.DoctorId;

            await _repository.UpdateAsync(appointment);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}