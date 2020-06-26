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
        private readonly IInscriptionProcessRepository _inscriptionProcessRepository;

        //CONSTRUCTOR
        public CourseService(ICourseRepository courseRepository, IUnitOfWork unitOfWork,
            IInscriptionProcessRepository inscriptionProcessRepository)
        {
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
            _inscriptionProcessRepository = inscriptionProcessRepository;
        }

        //HELPFULL METHODS
        private async Task<InscriptionProcess> FindInscriptionProcessById(int inscriptionProcessId)
        {
            var existingInscriptionProcess = await _inscriptionProcessRepository.FindByIdAsync(inscriptionProcessId);
            return existingInscriptionProcess;
        }
        private async Task<Course> FindCourseById(int courseId)
        {
            var existingCourse = await _courseRepository.FindByIdAsync(courseId);
            return existingCourse;
        }

        //CRUD METHODS

        //Create---------
        public async Task<CourseResponse> SaveAsync(int inscriptionProcessId, Course course)
        {
            //find inscription process
            if (await FindInscriptionProcessById(inscriptionProcessId) == null)
                return new CourseResponse($"Inscription process with id: {inscriptionProcessId} not found");

            //now add
            try
            {
                await _courseRepository.AddAsync(inscriptionProcessId, course);
                await _unitOfWork.CompleteAsync();

                return new CourseResponse(course);
            }
            catch (Exception ex)
            {
                return new CourseResponse($"An error ocurred while saving the course: {ex.Message}");
            }
        }

        //GetByInscriptionProcessId---------
        public async Task<IEnumerable<Course>> ListByInscriptionProcessIdAsync(int inscriptionProcessId)
        {
            return await _courseRepository.ListByInscriptionProcessIdAsync(inscriptionProcessId);
        }

        //GetByCourseId&InscriptionProcessId---------
        public async Task<CourseResponse> GetByIdAndInscriptionProcessIdAsync(int inscriptionProcessId, int courseId)
        {
            //find inscription process
            if (await FindInscriptionProcessById(inscriptionProcessId) == null)
                return new CourseResponse($"Inscription process with id: {inscriptionProcessId} not found");

            //find course 
            var existingCourse = await FindCourseById(courseId);

            if (existingCourse == null)
                return new CourseResponse($"Course with id: {courseId} not found");

            return new CourseResponse(existingCourse);
        }

        //Update---------
        public async Task<CourseResponse> UpdateAsync(int inscriptionProcessId, int courseId, Course course)
        {
            //find inscription process
            if (await FindInscriptionProcessById(inscriptionProcessId) == null)
                return new CourseResponse($"Inscription process with id: {inscriptionProcessId} not found");

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
        public async Task<CourseResponse> DeleteAsync(int inscriptionProcessId, int courseId)
        {
            //find inscription process
            if (await FindInscriptionProcessById(inscriptionProcessId) == null)
                return new CourseResponse($"Inscription process with id: {inscriptionProcessId} not found");

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
