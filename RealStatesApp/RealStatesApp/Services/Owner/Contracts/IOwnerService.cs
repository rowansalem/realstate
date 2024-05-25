using RealStatesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealStatesApp.Services.Owner.Contracts
{
    public interface IOwnersService
    {
        Task<List<OwnerDTO>> GetOwnersAsync();
        Task<OwnerDTO?> GetOwnerByIdAsync(Guid id);
        Task<bool?> CreateOwnerAsync(OwnerDTO owner);
        Task<bool?> UpdateOwnerAsync(OwnerDTO owner);

        Task<bool?> DeleteOwnerAsync(Guid id);
    }
}
