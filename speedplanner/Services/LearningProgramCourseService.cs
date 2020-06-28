using speedplanner.Domain.Models;
using speedplanner.Domain.Repositories;
using speedplanner.Domain.Services;
using speedplanner.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Services
{
    public class LearningProgramCourseService : ILearningProgramCourseService
    {
        private readonly ILearningProgramCourseRepository _learningProgramCourseRepository;
        public readonly IUnitOfWork _unitOfWork;
        private readonly IProfileRepository _profileRepository;
        private readonly ICourseRepository _courseRepository;

        public LearningProgramCourseService(ILearningProgramCourseRepository learningProgramCourseRepository, IUnitOfWork unitOfWork,
            IProfileRepository profileRepository, ICourseRepository courseRepository)
        {
            _learningProgramCourseRepository = learningProgramCourseRepository;
            _unitOfWork = unitOfWork;
            _profileRepository = profileRepository;
            _courseRepository = courseRepository;
        }


        public async Task<IEnumerable<LearningProgramCourse>> ListByProfileIdAsync(int profileId)
        {
            var existingProfile = await _profileRepository.FindById(profileId);

            if(existingProfile == null)
                return null;
            
            int learningProgramId = existingProfile.LearningProgramId;
            return await _learningProgramCourseRepository.ListByLearningProgramIdAsync(learningProgramId);

            
        }

        public async Task<IEnumerable<LearningProgramCourse>> ListAsync()
        {
            return await _learningProgramCourseRepository.ListAsync();
        }

        public async Task<IEnumerable<LearningProgramCourse>> ListByLearningProgramIdAsync(int learningProgramId)
        {
            return await _learningProgramCourseRepository.ListByLearningProgramIdAsync(learningProgramId);
        }

        public async Task<IEnumerable<LearningProgramCourse>> ListByCourseIdAsync(int courseId)
        {
            return await _learningProgramCourseRepository.ListByCourseIdAsync(courseId);
        }

        public async Task<LearningProgramCourseResponse> AssignLearningProgramCourseAsync(int learningProgramId, int courseId)
        {
            try
            {
                LearningProgramCourse learningProgramCourse = await _learningProgramCourseRepository.AssignLearningProgramCourse(learningProgramId, courseId);
                await _unitOfWork.CompleteAsync();
                return new LearningProgramCourseResponse(learningProgramCourse);
            }
            catch(Exception ex)
            {
                return new LearningProgramCourseResponse($"An error ocurred while assigning Course to LearningProgram: {ex.Message}");
            }

        }

        public async Task<LearningProgramCourseResponse> UnassignLearningProgramCourseAsync(int learningProgramId, int courseId)
        {
            try
            {
                LearningProgramCourse learningProgramCourse = await _learningProgramCourseRepository.UnassignLearningProgramCourse(learningProgramId, courseId);
                await _unitOfWork.CompleteAsync();
                return new LearningProgramCourseResponse(learningProgramCourse);
            }
            catch (Exception ex)
            {
                return new LearningProgramCourseResponse($"An error ocurred while unassigning Course to LearningProgram: {ex.Message}");
            }
        }
    }
}
