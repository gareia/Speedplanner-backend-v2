using speedplanner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Repositories
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> ListAsync();

        Task AddAsync(int userId, Role role);

        Task<Role> FindById(int id);

        Task<IEnumerable<Role>> ListByUserIdAsync(int userId);

        void Remove(Role role);

        void Update(Role role);
    }
}
