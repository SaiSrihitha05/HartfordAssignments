using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HospitalApiWithDb.InterfaceAdapters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _service;

        public PatientController(IPatientService service)
        {
            _service = service;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [Authorize(Roles = "Patient")]
        [HttpGet("my-profile")]
        public async Task<IActionResult> GetMyProfile()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                                   ?? User.FindFirst("sub")!.Value);

            return Ok(await _service.GetByIdAsync(userId));
        }

        [Authorize(Roles = "Patient")]
        [HttpGet("my-appointments")]
        public async Task<IActionResult> GetMyAppointments()
        {
            var userId = int.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            return Ok(await _service.GetMyAppointmentsAsync(userId));
        }

        [Authorize(Roles = "Patient")]
        [HttpPost("complete-profile")]
        public async Task<IActionResult> CompleteProfile(CompletePatientProfileDto dto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                                   ?? User.FindFirst("sub")!.Value);

            await _service.CompleteProfileAsync(userId, dto);

            return Ok("Profile completed successfully");
        }

        [Authorize(Roles = "Patient")]
        [HttpPut("update-profile")]
        public async Task<IActionResult> UpdateProfile(UpdatePatientDto dto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                                   ?? User.FindFirst("sub")!.Value);

            await _service.UpdateAsync(userId, dto);

            return Ok("Profile updated successfully");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}