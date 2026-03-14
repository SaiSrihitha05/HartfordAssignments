using HospitalApiWithDb.Models;
using HospitalApiWithDb.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApiWithDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorRepository _repository;

        public DoctorsController(IDoctorRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Doctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
        {
            var doctors = await _repository.GetAllAsync();
            return Ok(doctors);
        }

        // GET: api/Doctors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            var doctor = await _repository.GetByIdAsync(id);

            if (doctor == null)
                return NotFound();

            return Ok(doctor);
        }

        // PUT: api/Doctors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor(int id, Doctor doctor)
        {
            if (id != doctor.Id)
                return BadRequest();

            var existingDoctor = await _repository.GetByIdAsync(id);
            if (existingDoctor == null)
                return NotFound();

            await _repository.UpdateAsync(doctor);

            return NoContent();
        }

        // POST: api/Doctors
        [HttpPost]
        public async Task<ActionResult<Doctor>> PostDoctor(Doctor doctor)
        {
            await _repository.AddAsync(doctor);

            return CreatedAtAction(nameof(GetDoctor),
                new { id = doctor.Id },
                doctor);
        }

        // DELETE: api/Doctors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var existingDoctor = await _repository.GetByIdAsync(id);
            if (existingDoctor == null)
                return NotFound();

            await _repository.DeleteAsync(id);

            return NoContent();
        }
    }
}
