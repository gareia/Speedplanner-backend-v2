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
    public class SectionService : ISectionService
    {

        private readonly ISectionRepository _sectionRepository;
        private readonly ICourseRepository _courseRepository;
        public readonly IUnitOfWork _unitOfWork;

        public SectionService(ISectionRepository sectionRepository, IUnitOfWork unitOfWork,
            ICourseRepository courseRepository)
        {
            _sectionRepository = sectionRepository;
            _unitOfWork = unitOfWork;
            _courseRepository = courseRepository;
        }

        //HELPFULL METHODS
        private async Task<Course> FindCourseById(int courseId)
        {
            var existingCourse= await _courseRepository.FindByIdAsync(courseId);
            return existingCourse;
        }

        private async Task<Section> FindSectionById(int sectionId)
        {
            var existingSection = await _sectionRepository.FindById(sectionId);
            return existingSection;
        }
        /*
        public async Task<SectionResponse> DeleteAsync(int id)
        {
            var existingService = await _sectionRepository.FindById(id);
            if (existingService == null)
                return new SectionResponse("Section not found");
            try
            {
                await _sectionRepository.Remove(existingService);
                return new SectionResponse(existingService);
            }
            catch (Exception ex)
            {
                return new SectionResponse($"An error occurred while deleting the section: {ex.Message}");
            }

        }*/

        public async Task<SectionResponse> GetByIdAndCourseIdAsync(int courseId, int id)
        {
            //find course
            if (await FindCourseById(courseId) == null)
                return new SectionResponse($"Course with id: {courseId} not found");

            //find section
            var existingSection = await FindSectionById(id);
            if (existingSection == null)
                return new SectionResponse($"Section with id: {id} not found");
            return new SectionResponse(existingSection);
        }
        public async Task<IEnumerable<Section>> ListByCourseIdAsync(int courseId)
        {
            return await _sectionRepository.ListByCourseAsync(courseId);
        }

        public async Task<SectionResponse> SaveAsync(int courseId, Section section)
        {
            //find course
            if (await FindCourseById(courseId) == null)
                return new SectionResponse($"Course with id: {courseId} not found");


            //now add
            try
            {
                await _sectionRepository.AddAsync(courseId,section);
                await _unitOfWork.CompleteAsync();
                return new SectionResponse(section);
            }
            catch (Exception ex)
            {
                return new SectionResponse($"An error occurred while saving the section: {ex.Message}");
            }

        }
        /*
        public async Task<SectionResponse> UpdateAsync(int id, Section section)
        {
            var existingService = await _sectionRepository.FindById(id);
            if (existingService == null)
                return new SectionResponse("Section not found");
            existingService.RegisteredStudents = section.RegisteredStudents;
            existingService.SectionName = section.SectionName;
            existingService.Vacancy = section.Vacancy;
            existingService.Venue = section.Venue;
            try
            {
                await _sectionRepository.Update(existingService);
                await _unitOfWork.CompleteAsync();
                return new SectionResponse(existingService);
            }
            catch (Exception ex)
            {
                return new SectionResponse($"An error occurred while updating the section: {ex.Message}");
            }
        }*/
    }
}
