using Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IOfficeRepository
    {
        Task<Office> GetOfficeWithUsersByIdAsync(int id);
        Task<IReadOnlyList<Office>> GetOfficesWithUsersAsync();
        Task<IReadOnlyList<Office>> GetOfficesAsync();
    }
}
