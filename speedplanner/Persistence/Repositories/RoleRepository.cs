using Microsoft.EntityFrameworkCore;
using speedplanner.Domain.Models;
using speedplanner.Domain.Persistence.Contexts;
using speedplanner.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Persistence.Repositories
{
    public class RoleRepository:BaseRepository, IRoleRepository
    {
        public RoleRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(int userId, Role role)
        {
            role.UserId = userId;
            await _context.Roles.AddAsync(role);
        }

        public async Task<Role> FindById(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task<IEnumerable<Role>> ListAsync()
        {
            return await _context.Roles.ToListAsync();
        }


        public async Task<IEnumerable<Role>> ListByUserIdAsync(int userId) =>
            await _context.Roles
            .Where(p => p.UserId == userId)
            .Include(p => p.User)
            .ToListAsync();

        public void Remove(Role role)
        {
            _context.Roles.Remove(role);
        }

        public void Update(Role role)
        {
            _context.Roles.Update(role);
        }
    }
}
