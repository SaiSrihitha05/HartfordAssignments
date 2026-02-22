using Application.DTOs;
using Application.Interfaces.Repositories;
using Domain.Entities;
using System.Security.Claims;
using System.Linq;

namespace Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repository;
        private readonly IPatientRepository _patientRepository;

        public AppointmentService(IAppointmentRepository repository,IPatientRepository patientRepository)
        {
            _repository = repository;
            _patientRepository = patientRepository;
        }

        public async Task<IEnumerable<AppointmentResponseDto>> GetAllAsync()
        {
            var appointments = await _repository.GetAllAsync();

            return appointments.Select(a => new AppointmentResponseDto
            {
                Id = a.Id,
                DoctorId = a.DoctorId,
                DoctorName = a.Doctor != null ? a.Doctor.Name : "",
                PatientId = a.PatientId,
                PatientName = a.Patient != null ? a.Patient.Name : "",
                AppointmentDate = a.Date,
                Status = a.Status
            });
        }

        public async Task<AppointmentResponseDto?> GetByIdAsync(int id)
        {
            var appointment = await _repository.GetByIdAsync(id);
            if (appointment == null) return null;

            return new AppointmentResponseDto
            {
                Id = appointment.Id,
                DoctorId = appointment.DoctorId,
                DoctorName = appointment.Doctor != null ? appointment.Doctor.Name : "",
                PatientId = appointment.PatientId,
                PatientName = appointment.Patient != null ? appointment.Patient.Name : "",
                AppointmentDate = appointment.Date,
                Status = appointment.Status
            };
        }

        public async Task<AppointmentResponseDto> CreateAsync(int userId,CreateAppointmentDto dto)
        {
            var patient = await _patientRepository.GetByUserIdAsync(userId);

            if (patient == null || !patient.IsProfileCompleted)
                throw new Exception("Complete your profile before booking appointment");
            var appointment = new Appointment
            {
                DoctorId = dto.DoctorId,
                PatientId = patient.Id,
                Date = dto.AppointmentDate,
                Status = "Scheduled"   // default string
            };

            await _repository.AddAsync(appointment);

            return new AppointmentResponseDto
            {
                Id = appointment.Id,
                DoctorId = appointment.DoctorId,
                PatientId = appointment.PatientId,
                AppointmentDate = appointment.Date,
                Status = appointment.Status
            };
        }

        public async Task UpdateAsync(int id, UpdateAppointmentDto dto)
        {
            var appointment = await _repository.GetByIdAsync(id);
            if (appointment == null)
                throw new Exception("Appointment not found");

            appointment.DoctorId = dto.DoctorId;
            appointment.PatientId = dto.PatientId;
            appointment.Date = dto.AppointmentDate;
            appointment.Status = dto.Status;   // direct string assignment

            await _repository.UpdateAsync(appointment);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<AppointmentInsideDoctorDto>> GetByDoctorAsync(int doctorId)
        {
            var appointments = await _repository.GetByDoctorIdAsync(doctorId);

            return appointments.Select(a => new AppointmentInsideDoctorDto
            {
                Id = a.Id,
                PatientId = a.PatientId, // Map the ID here
                DoctorId = a.DoctorId,   // Map the ID here
                PatientName = a.Patient.Name,
                AppointmentDate = a.Date,
                Status = a.Status
            });
        }

        public async Task<IEnumerable<AppointmentResponseDto>> GetByPatientAsync(int patientId)
        {
            var appointments = await _repository.GetByPatientIdAsync(patientId);

            return appointments.Select(a => new AppointmentResponseDto
            {
                Id = a.Id,
                DoctorId = a.DoctorId,
                DoctorName = a.Doctor != null ? a.Doctor.Name : "",
                PatientId = a.PatientId,
                PatientName = a.Patient != null ? a.Patient.Name : "",
                AppointmentDate = a.Date,
                Status = a.Status
            });
        }
    }
}