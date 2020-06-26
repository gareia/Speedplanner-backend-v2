using speedplanner.Domain.Models;
using speedplanner.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Services
{
    public interface IInscriptionProcessService
    {
        
        Task<InscriptionProcessResponse> SaveAsync(int userId, InscriptionProcess inscriptionProcess);
        //Task<IEnumerable<InscriptionProcess>> ListAsync();
        Task<IEnumerable<InscriptionProcess>> ListByUserIdAsync(int userId);
        Task<InscriptionProcessResponse> GetByIdAndUserIdAsync(int userId, int inscriptionProcessId); 
        //No update
        Task<InscriptionProcessResponse> DeleteAsync(int userId, int inscriptionProcessId);
        
    }
}
