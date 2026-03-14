using Notice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notice.Domain.Interfaces
{
    public interface INoticeRepository
    {
        Task<NoticeEntry?> GetByIdAsync(Guid id);
        Task<IEnumerable<NoticeEntry>> GetAllAsync();
        Task AddAsync(NoticeEntry notice);
        Task UpdateAsync(NoticeEntry notice);
        Task DeleteAsync(Guid id);
    }
}
