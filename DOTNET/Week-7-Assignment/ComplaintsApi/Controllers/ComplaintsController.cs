using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ComplaintsApi.Models;
using ComplaintsApi.DTOs;

namespace ComplaintsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintsController : ControllerBase
    {
        private readonly ComplaintContext _context;

        public ComplaintsController(ComplaintContext context)
        {
            _context = context;
        }

        // GET: api/Complaints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComplaintResponseDto>>> GetComplaints()
        {
            var complaints = await _context.Complaints
                .Select(c => new ComplaintResponseDto
                {
                    Id = c.Id,
                    Title = c.Title,
                    CustomerName = c.CustomerName,
                    Status = c.Status,
                    CreatedAt = c.CreatedAt
                })
                .ToListAsync();

            return Ok(complaints);
        }

        // GET: api/Complaints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComplaintResponseDto>> GetComplaint(int id)
        {
            var complaint = await _context.Complaints.FindAsync(id);

            if (complaint == null)
                return NotFound();

            var response = new ComplaintResponseDto
            {
                Id = complaint.Id,
                Title = complaint.Title,
                CustomerName = complaint.CustomerName,
                Status = complaint.Status,
                CreatedAt = complaint.CreatedAt
            };

            return Ok(response);
        }

        // POST: api/Complaints
        [HttpPost]
        public async Task<ActionResult<ComplaintResponseDto>> PostComplaint(CreateComplaintDto dto)
        {
            var complaint = new Complaint
            {
                Title = dto.Title,
                Description = dto.Description,
                CustomerName = dto.CustomerName,
                CustomerEmail = dto.CustomerEmail,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow
            };

            _context.Complaints.Add(complaint);
            await _context.SaveChangesAsync();

            var response = new ComplaintResponseDto
            {
                Id = complaint.Id,
                Title = complaint.Title,
                CustomerName = complaint.CustomerName,
                Status = complaint.Status,
                CreatedAt = complaint.CreatedAt
            };

            return CreatedAtAction(nameof(GetComplaint),
                new { id = complaint.Id },
                response);
        }

        // PUT: api/Complaints/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComplaint(int id, UpdateComplaintDto dto)
        {
            var complaint = await _context.Complaints.FindAsync(id);

            if (complaint == null)
                return NotFound();

            if (!string.IsNullOrEmpty(dto.Title))
                complaint.Title = dto.Title;

            if (!string.IsNullOrEmpty(dto.Description))
                complaint.Description = dto.Description;

            if (!string.IsNullOrEmpty(dto.Status))
                complaint.Status = dto.Status;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Complaints/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComplaint(int id)
        {
            var complaint = await _context.Complaints.FindAsync(id);

            if (complaint == null)
                return NotFound();

            _context.Complaints.Remove(complaint);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}