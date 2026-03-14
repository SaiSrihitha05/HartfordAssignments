using Notice.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notice.Application.Interfaces
{
    public interface INoticeService
    {
        Task<NoticeDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<NoticeDto>> GetAllAsync();
        Task<NoticeDto> CreateAsync(CreateNoticeRequest request);
        Task<bool> UpdateAsync(Guid id, UpdateNoticeRequest request);
        Task<bool> DeleteAsync(Guid id);
    }
}
