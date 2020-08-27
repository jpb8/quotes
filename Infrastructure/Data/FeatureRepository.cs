using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class FeatureRepository : IFeatureRepository
    {
        private readonly StoreContext _context;

        public FeatureRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<Feature> GetFeatureByIdAsync(int id)
        {
            return await _context.Features
                .Include(p => p.Project)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Feature>> GetFeaturesAsync()
        {
            return await _context.Features
                .Include(p => p.Project)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ResourceType>> GetResourceTypesAsync()
        {
            return await _context.ResourceTypes.ToListAsync();
        }
    }
}
