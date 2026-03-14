using Notice.Application.DTOs;
using Notice.Application.Interfaces;
using Notice.Domain.Entities;
using Notice.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notice.Application.Services
{
    public class NoticeService : INoticeService
    {
        private readonly INoticeRepository _repository;

        public NoticeService(INoticeRepository repository)
        {
            _repository = repository;
        }

        public async Task<NoticeDto?> GetByIdAsync(Guid id)
        {
            var notice = await _repository.GetByIdAsync(id);
            if (notice == null) return null;
            return new NoticeDto(notice.Id, notice.Title, notice.Description, notice.PostedBy, notice.CreatedDate);
        }

        public async Task<IEnumerable<NoticeDto>> GetAllAsync()
        {
            var notices = await _repository.GetAllAsync();
            return notices.Select(n => new NoticeDto(n.Id, n.Title, n.Description, n.PostedBy, n.CreatedDate));
        }

        public async Task<NoticeDto> CreateAsync(CreateNoticeRequest request)
        {
            var notice = new NoticeEntry
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                PostedBy = request.PostedBy,
                CreatedDate = DateTime.UtcNow
            };

            await _repository.AddAsync(notice);
            return new NoticeDto(notice.Id, notice.Title, notice.Description, notice.PostedBy, notice.CreatedDate);
        }

        public async Task<bool> UpdateAsync(Guid id, UpdateNoticeRequest request)
        {
            var notice = await _repository.GetByIdAsync(id);
            if (notice == null) return false;

            notice.Title = request.Title;
            notice.Description = request.Description;

            await _repository.UpdateAsync(notice);
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var notice = await _repository.GetByIdAsync(id);
            if (notice == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
