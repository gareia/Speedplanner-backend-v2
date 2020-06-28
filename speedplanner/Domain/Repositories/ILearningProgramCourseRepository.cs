using speedplanner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Repositories
{
    public interface ILearningProgramCourseRepository
    {
        
        Task<IEnumerable<LearningProgramCourse>> ListAsync();
        Task<IEnumerable<LearningProgramCourse>> ListByLearningProgramIdAsync(int learningProgramId);
        Task<IEnumerable<LearningProgramCourse>> ListByCourseIdAsync(int courseId);
        Task<LearningProgramCourse> AssignLearningProgramCourse(int learningProgramId, int courseId);
        Task<LearningProgramCourse> UnassignLearningProgramCourse(int learningProgramId, int courseId);

        Task<LearningProgramCourse> FindByLearningProgramIdAndCourseId(int learningProgramId, int courseId);
        Task AddAsync(LearningProgramCourse learningProgramCourse);
        void Remove(LearningProgramCourse learningProgramCourse);
        
}
}
