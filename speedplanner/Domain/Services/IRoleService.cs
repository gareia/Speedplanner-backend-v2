using speedplanner.Domain.Models;
using speedplanner.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Services
{
    public interface IRoleService
    {
        Task<RoleResponse> SaveAsync(int userId, Role role);
        Task<RoleResponse> GetByIdAndUserIdAsync(int userId, int roleId);

        /*
        Task<IEnumerable<Role>> ListAsync();
        Task<IEnumerable<Role>> ListByUserIdAsync(int userId);
        Task<RoleResponse> UpdateAsync(int id, int type);
        Task<RoleResponse> DeleteAsync(int id);*/
    }
}
