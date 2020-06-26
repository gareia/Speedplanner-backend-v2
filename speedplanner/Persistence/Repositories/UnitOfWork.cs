using speedplanner.Domain.Persistence.Contexts;
using speedplanner.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Persistence.Repositories
{
    //agregue BaseRepository
    public class UnitOfWork : BaseRepository, IUnitOfWork
    {
   

        public UnitOfWork(AppDbContext context): base(context)
        {
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
    
}
