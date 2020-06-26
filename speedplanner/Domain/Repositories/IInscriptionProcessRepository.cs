using speedplanner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Repositories
{
    public interface IInscriptionProcessRepository
    {
        
        Task AddAsync(int userId, InscriptionProcess inscriptionProcess);
        //Task<IEnumerable<InscriptionProcess>> ListAsync();
        Task<IEnumerable<InscriptionProcess>> ListByUserIdAsync(int userId);
        Task<InscriptionProcess> FindByIdAsync(int inscriptionProcessId);
        //no hay update
        void Remove(InscriptionProcess inscriptionProcess);
       
    }
}
