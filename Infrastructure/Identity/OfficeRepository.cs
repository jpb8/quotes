using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Identity
{
    public class OfficeRepository : IOfficeRepository
    {
        private readonly AppIdentityDbContext _context;

        public OfficeRepository(AppIdentityDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Office>> GetOfficesAsync()
        {
            return await _context.Office.ToListAsync();
        }

        public  async Task<IReadOnlyList<Office>> GetOfficesWithUsersAsync()
        {
            return await _context.Office
                .Include(p => p.Users)
                .ToListAsync();
        }

        public async Task<Office> GetOfficeWithUsersByIdAsync(int id)
        {
            return await _context.Office
                .Include(p => p.Users)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
