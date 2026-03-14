using Microsoft.EntityFrameworkCore;
using Notice.Domain.Entities;
using Notice.Domain.Interfaces;
using Notice.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notice.Infrastructure.Repositories
{
    public class NoticeRepository : INoticeRepository
    {
        private readonly NoticeDbContext _context;

        public NoticeRepository(NoticeDbContext context)
        {
            _context = context;
        }

        public async Task<NoticeEntry?> GetByIdAsync(Guid id)
        {
            return await _context.Notices.FindAsync(id);
        }

        public async Task<IEnumerable<NoticeEntry>> GetAllAsync()
        {
            return await _context.Notices.ToListAsync();
        }

        public async Task AddAsync(NoticeEntry notice)
        {
            await _context.Notices.AddAsync(notice);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(NoticeEntry notice)
        {
            _context.Notices.Update(notice);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var notice = await _context.Notices.FindAsync(id);
            if (notice != null)
            {
                _context.Notices.Remove(notice);
                await _context.SaveChangesAsync();
            }
        }
    }
}
