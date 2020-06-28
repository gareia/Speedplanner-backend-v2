using speedplanner.Domain.Models;
using speedplanner.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Services
{
    public interface IProfileService
    {
        Task<ProfileResponse> SaveAsync(int userId, Profile profile);
        Task<ProfileResponse> GetByIdAndUserIdAsync(int userId, int id);

        /*
        Task<ProfileResponse> UpdateAsync(int id, Profile profile);
        Task<ProfileResponse> DeleteAsync(int id);
        Task<IEnumerable<Profile>> ListAsync();
        */

    }
}
