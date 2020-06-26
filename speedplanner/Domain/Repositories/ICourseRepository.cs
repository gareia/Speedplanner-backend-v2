using speedplanner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Repositories
{
    public interface ICourseRepository
    {
        Task AddAsync(int inscriptionProcessId, Course course);
        Task<IEnumerable<Course>> ListByInscriptionProcessIdAsync(int inscriptionProcessId);
        Task<Course> FindByIdAsync(int courseId);
        void Update(Course course);
        void Remove(Course course);
    }
}
