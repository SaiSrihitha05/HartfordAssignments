using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notice.Application.DTOs;
using Notice.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class NoticeController : ControllerBase
    {
        private readonly INoticeService _noticeService;

        public NoticeController(INoticeService noticeService)
        {
            _noticeService = noticeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NoticeDto>>> GetAll()
        {
            var notices = await _noticeService.GetAllAsync();
            return Ok(notices);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NoticeDto>> GetById(Guid id)
        {
            var notice = await _noticeService.GetByIdAsync(id);
            if (notice == null) return NotFound();
            return Ok(notice);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<NoticeDto>> Create([FromBody] CreateNoticeRequest request)
        {
            var notice = await _noticeService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = notice.Id }, notice);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateNoticeRequest request)
        {
            var result = await _noticeService.UpdateAsync(id, request);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _noticeService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
