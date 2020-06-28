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
    public class CourseService: ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public readonly IUnitOfWork _unitOfWork;
        private readonly IEducationProviderRepository _educationProviderRepository;
        private readonly IProfileRepository _profileRepository;
        private readonly ILearningProgramCourseRepository _learningProgramCourseRepository;
        

        //CONSTRUCTOR
        public CourseService(ICourseRepository courseRepository, IUnitOfWork unitOfWork,
             IEducationProviderRepository educationProviderRepository, IProfileRepository profileRepository,
             ILearningProgramCourseRepository learningProgramCourseRepository)
        {
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
            _educationProviderRepository = educationProviderRepository;
            _profileRepository = profileRepository;
            _learningProgramCourseRepository = learningProgramCourseRepository;
           
        }

        //HELPFULL METHODS
        private async Task<EducationProvider> FindEducationProviderById(int educationProviderId)
        {
            var existingEducationProvider = await _educationProviderRepository.FindById(educationProviderId);
            return existingEducationProvider;
        }
        private async Task<Course> FindCourseById(int courseId)
        {
            var existingCourse = await _courseRepository.FindByIdAsync(courseId);
            return existingCourse;
        }

        //CRUD METHODS

        public async Task<IEnumerable<Course>> ListByProfileIdAsync(int profileId)
        {
            var existingProfile = await _profileRepository.FindById(profileId);
            if (existingProfile == null)
                return null;

            int learningProgramId = existingProfile.LearningProgramId;

            var learningProgramCourses = await _learningProgramCourseRepository.ListByLearningProgramIdAsync(learningProgramId);
            var courses = learningProgramCourses.Select(lpc => lpc.Course).ToList();
            return courses;
        }

        //Read courses by education provider id
        public async Task<IEnumerable<Course>> ListByEducationProviderIdAsync(int educationProviderId)
        {
            return await _courseRepository.ListByEducationProviderIdAsync(educationProviderId);
        }

        //Create---------
        public async Task<CourseResponse> SaveAsync(int educationProviderId, Course course)
        {
            //find education provider
            if (await FindEducationProviderById(educationProviderId) == null)
                return new CourseResponse($"Education provider with id: {educationProviderId} not found");

            //now add
            try
            {
                await _courseRepository.AddAsync(educationProviderId, course);
                await _unitOfWork.CompleteAsync();

                return new CourseResponse(course);
            }
            catch (Exception ex)
            {
                return new CourseResponse($"An error ocurred while saving the course: {ex.Message}");
            }
        }

        /*
        //GetByInscriptionProcessId---------
        public async Task<IEnumerable<Course>> ListByInscriptionProcessIdAsync(int inscriptionProcessId)
        {
            return await _courseRepository.ListByInscriptionProcessIdAsync(inscriptionProcessId);
        }*/

        //GetByCourseId&InscriptionProcessId---------
        public async Task<CourseResponse> GetByIdAndEducationProviderIdAsync(int educationProviderId, int courseId)
        {
            //find education provider
            if (await FindEducationProviderById(educationProviderId) == null)
                return new CourseResponse($"Education provider with id: {educationProviderId} not found");

            //find course 
            var existingCourse = await FindCourseById(courseId);

            if (existingCourse == null)
                return new CourseResponse($"Course with id: {courseId} not found");

            return new CourseResponse(existingCourse);
        }

        //Update---------
        public async Task<CourseResponse> UpdateAsync(int educationProviderId, int courseId, Course course)
        {
            //find education provider
            if (await FindEducationProviderById(educationProviderId) == null)
                return new CourseResponse($"Education provider with id: {educationProviderId} not found");

            //find course 
            var existingCourse = await FindCourseById(courseId);

            if (existingCourse == null)
                return new CourseResponse($"Course with id: {courseId} not found");

            //now update
            existingCourse.Code = course.Code;
            existingCourse.Name = course.Name;
            existingCourse.TotalNumberOfStudents = course.TotalNumberOfStudents;
            existingCourse.IsOptional = course.IsOptional;
            existingCourse.IsVirtual = course.IsVirtual;
            existingCourse.Semester = course.Semester;
            existingCourse.Credits = course.Credits;

            try
            {
                _courseRepository.Update(existingCourse);
                await _unitOfWork.CompleteAsync();

                return new CourseResponse(existingCourse);
            }
            catch (Exception ex)
            {
                return new CourseResponse($"An error ocurred while updating course {ex.Message}");
            }
        }

        //Delete---------
        public async Task<CourseResponse> DeleteAsync(int educationProviderId, int courseId)
        {
            //find education provider
            if (await FindEducationProviderById(educationProviderId) == null)
                return new CourseResponse($"Education provider with id: {educationProviderId} not found");

            //find course 
            var existingCourse = await FindCourseById(courseId);

            if (existingCourse == null)
                return new CourseResponse($"Course with id: {courseId} not found");

            //now delete
            try
            {
                _courseRepository.Remove(existingCourse);
                await _unitOfWork.CompleteAsync();

                return new CourseResponse(existingCourse);
            }
            catch (Exception ex)
            {
                return new CourseResponse($"An error ocurred while deleting course {ex.Message}");
            }
        }
    }

}
