using RealStatesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealStatesApp.Services.Property.Contracts
{
    public interface IPropertiesService
    {
        Task<List<PropertyDTO>> GetPropertiesAsync();
        Task<PropertyDTO?> GetPropertyByIdAsync(Guid id);
        Task<bool?> CreatePropertyAsync(PropertyDTO property);
        Task<bool?> UpdatePropertyAsync(PropertyDTO property);

        Task<bool?> DeletePropertyAsync(Guid id);
    }
}
