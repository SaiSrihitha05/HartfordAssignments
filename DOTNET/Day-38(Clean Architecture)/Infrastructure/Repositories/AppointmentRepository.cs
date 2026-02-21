using HospitalApiWithDb.Application.Interfaces.Repositories;
using HospitalApiWithDb.Domain.Entities;
using HospitalApiWithDb.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalApiWithDb.Infrastructure.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly HospitalDbContext _context;

        public AppointmentRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync()
            => await _context.Appointments
                .Include(a => a.Doctor)
                .ToListAsync();

        public async Task<Appointment?> GetByIdAsync(int id)
            => await _context.Appointments
                .Include(a => a.Doctor)
                .FirstOrDefaultAsync(a => a.Id == id);

        public async Task AddAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
            => await _context.Appointments.AnyAsync(a => a.Id == id);
    }
}