using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IFeatureRepository
    {
        Task<Feature> GetFeatureByIdAsync(int id);
        Task<IReadOnlyList<Feature>> GetFeaturesAsync();
        Task<IReadOnlyList<ResourceType>> GetResourceTypesAsync();
    }
}
