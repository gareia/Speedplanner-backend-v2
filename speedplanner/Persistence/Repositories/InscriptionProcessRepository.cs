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
    /*
    public class InscriptionProcessRepository : BaseRepository, IInscriptionProcessRepository
    {
        public InscriptionProcessRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(int userId, InscriptionProcess inscriptionProcess)
        {
            inscriptionProcess.UserId = userId;
            await _context.InscriptionProcesses.AddAsync(inscriptionProcess);
        }

        /*
        public async Task<IEnumerable<InscriptionProcess>> ListAsync()
        {
            return await _context.InscriptionProcesses.Include(ip => ip.User).ToListAsync();
        }

        public async Task<IEnumerable<InscriptionProcess>> ListByUserIdAsync(int userId)
        {
            return await _context.InscriptionProcesses
            .Where(ip => ip.UserId == userId)
            .Include(ip => ip.User)
            .ToListAsync();
        }
        public async Task<IEnumerable<InscriptionProcess>> ListAllByPeriodIdAsyn(int periodId)
        {
            return await _context.InscriptionProcesses
                .Where(ip => ip.PeriodId == periodId)
                .Include(ip => ip.Period)
                .ToListAsync();
        }


        public async Task<InscriptionProcess> FindByIdAsync(int inscriptionProcessId)
        {
            return await _context.InscriptionProcesses.FindAsync(inscriptionProcessId);
        }
        
        public void Remove(InscriptionProcess inscriptionProcess)
        {
             _context.InscriptionProcesses.Remove(inscriptionProcess);
        }

        
    }*/
}
