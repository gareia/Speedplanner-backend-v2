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
    public class LearningProgramService : ILearningProgramService
    {
        private readonly ILearningProgramRepository _learningProgramRepository;
        public readonly IUnitOfWork _unitOfWork;
        private readonly IEducationProviderRepository _educationProviderRepository;

        //CONSTRUCTOR
        public LearningProgramService(ILearningProgramRepository learningProgramRepository, IUnitOfWork unitOfWork,
            IEducationProviderRepository educationProviderRepository)
        {
            _learningProgramRepository = learningProgramRepository;
            _unitOfWork = unitOfWork;
            _educationProviderRepository = educationProviderRepository;
        }

        //HELPFULL METHODS
        private async Task<EducationProvider> FindEducationProviderById(int educationProviderId)
        {
            var existingEducationProvider = await _educationProviderRepository.FindById(educationProviderId);
            return existingEducationProvider;
        }

        private async Task<LearningProgram> FindLearningProgramById(int learningProgramId)
        {
            var existingLearningProgram = await _learningProgramRepository.FindByIdAsync(learningProgramId);
            return existingLearningProgram;
        }

        //CRUD METHODS

        //Create---------
        public async Task<LearningProgramResponse> SaveAsync(int educationProviderId, LearningProgram learningProgram)
        {
            //find education provider
            if (await FindEducationProviderById(educationProviderId) == null)
                return new LearningProgramResponse($"Education provider with id: {educationProviderId} not found");

            //now add
            try
            {
                await _learningProgramRepository.AddAsync(educationProviderId, learningProgram);
                await _unitOfWork.CompleteAsync();

                return new LearningProgramResponse(learningProgram);
            }
            catch(Exception ex)
            {
                return new LearningProgramResponse($"An error ocurred while saving the learningProgram: {ex.Message}");
            }
        }

        //GetByEducationProviderId---------
        public async Task<IEnumerable<LearningProgram>> ListByEducationProviderIdAsync(int educationProviderId)
        {
            return await _learningProgramRepository.ListByEducationProviderIdAsync(educationProviderId);
        }

        //GetByLearningProgramId&EducationProviderId---------
        public async Task<LearningProgramResponse> GetByIdAndEducationProviderIdAsync(int educationProviderId, int learningProgramId)
        {
            //find education provider
            if (await FindEducationProviderById(educationProviderId) == null)
                return new LearningProgramResponse($"Education provider with id: {educationProviderId} not found");

            //find learning program
            var existingLearningProgram = await FindLearningProgramById(learningProgramId);

            if (existingLearningProgram == null)
                return new LearningProgramResponse($"Learning program with id: {learningProgramId} not found");

            return new LearningProgramResponse(existingLearningProgram);
        }

        //Update---------
        public async Task<LearningProgramResponse> UpdateAsync(int educationProviderId, int learningProgramId, LearningProgram learningProgram)
        {
            //find education provider
            if (await FindEducationProviderById(educationProviderId) == null)
                return new LearningProgramResponse($"Education provider with id: {educationProviderId} not found");

            //find learning program
            var existingLearningProgram = await FindLearningProgramById(learningProgramId);

            if (existingLearningProgram == null)
                return new LearningProgramResponse($"Learning program with id: {learningProgramId} not found");

            //now update
            existingLearningProgram.Type = learningProgram.Type;
            existingLearningProgram.Name = learningProgram.Name;
            existingLearningProgram.NumberOfCourses = learningProgram.NumberOfCourses;

            try
            {
                _learningProgramRepository.Update(existingLearningProgram);
                await _unitOfWork.CompleteAsync();

                return new LearningProgramResponse(existingLearningProgram);
            }
            catch(Exception ex)
            {
                return new LearningProgramResponse($"An error ocurred while updating learningProgram {ex.Message}");
            }
        }

        //Delete---------
        public async Task<LearningProgramResponse> DeleteAsync(int educationProviderId, int learningProgramId)
        {
            //find education provider
            if (await FindEducationProviderById(educationProviderId) == null)
                return new LearningProgramResponse($"Education provider with id: {educationProviderId} not found");

            //find learning program
            var existingLearningProgram = await FindLearningProgramById(learningProgramId);

            if (existingLearningProgram == null)
                return new LearningProgramResponse($"Learning program with id: {learningProgramId} not found");

            //now delete
            try
            {
                _learningProgramRepository.Remove(existingLearningProgram);
                await _unitOfWork.CompleteAsync();

                return new LearningProgramResponse(existingLearningProgram);
            }
            catch(Exception ex)
            {
                return new LearningProgramResponse($"An error ocurred while deleting learningProgram {ex.Message}");
            }
        }
    }
}
