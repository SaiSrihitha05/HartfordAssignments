using HospitalApiWithDb.Application.DTOs;
using HospitalApiWithDb.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApiWithDb.InterfaceAdapters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _service;

        public DoctorsController(IDoctorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorResponseDto>>> GetDoctors()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorResponseDto>> GetDoctor(int id)
        {
            var doctor = await _service.GetByIdAsync(id);
            if (doctor == null) return NotFound();
            return Ok(doctor);
        }

        [HttpPost]
        public async Task<ActionResult<DoctorResponseDto>> PostDoctor(CreateDoctorDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetDoctor),
                new { id = created.Id },
                created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor(int id, UpdateDoctorDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}