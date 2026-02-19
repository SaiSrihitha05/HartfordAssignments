using HospitalApiWithDb.Models;
using HospitalApiWithDb.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApiWithDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentRepository _repository;

        public AppointmentsController(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Appointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
            var appointments = await _repository.GetAllAsync();
            return Ok(appointments);
        }

        // GET: api/Appointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(int id)
        {
            var appointment = await _repository.GetByIdAsync(id);

            if (appointment == null)
                return NotFound();

            return Ok(appointment);
        }

        // PUT: api/Appointments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointment(int id, Appointment appointment)
        {
            if (id != appointment.Id)
                return BadRequest();

            var exists = await _repository.ExistsAsync(id);
            if (!exists)
                return NotFound();

            await _repository.UpdateAsync(appointment);

            return NoContent();
        }

        // POST: api/Appointments
        [HttpPost]
        public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
        {
            await _repository.AddAsync(appointment);

            return CreatedAtAction(nameof(GetAppointment),
                new { id = appointment.Id },
                appointment);
        }

        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var exists = await _repository.ExistsAsync(id);
            if (!exists)
                return NotFound();

            await _repository.DeleteAsync(id);

            return NoContent();
        }
    }
}
