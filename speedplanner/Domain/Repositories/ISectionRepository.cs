using speedplanner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Repositories
{
    public interface ISectionRepository
    {
            Task<IEnumerable<Section>> ListByCourseAsync(int courseId);

            Task AddAsync(int courseId, Section section);

            Task<Section> FindById(int id);

            //Task<IEnumerable<Section>> ListByProfessorIdAsync(int professorId);

            void Remove(Section section);

            void Update(Section section);
        
    }
}
