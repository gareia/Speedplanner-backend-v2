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
    public class EducationProviderService : IEducationProviderService
    {
        private readonly IEducationProviderRepository _educationProviderRepository;
        public readonly IUnitOfWork _unitOfWork;
        private readonly IProfileRepository _profileRepository;

        public EducationProviderService(IEducationProviderRepository educationProviderRepository, IUnitOfWork unitOfWork,
            IProfileRepository profileRepository)
        {
            _educationProviderRepository = educationProviderRepository;
            _unitOfWork = unitOfWork;
            _profileRepository = profileRepository;
        }
        
        public async Task<EducationProviderResponse> SaveAsync(EducationProvider educationProvider)
        {
            try
            {
                await _educationProviderRepository.AddAsync(educationProvider);
                await _unitOfWork.CompleteAsync();

                return new EducationProviderResponse(educationProvider);
            }
            catch(Exception ex)
            {
                return new EducationProviderResponse($"An error ocurred while saving the educationProvider: {ex.Message}");
            }
        }

        public async Task<IEnumerable<EducationProvider>> ListAsync()
        {
            return await _educationProviderRepository.ListAsync();
        }

        
        public async Task<EducationProviderResponse> GetByIdAsync(int id)
        {
            var existingEducationProvider = await _educationProviderRepository.FindById(id);

            if (existingEducationProvider == null)
                return new EducationProviderResponse($"EducationProvider with id: {id} not found");
            return new EducationProviderResponse(existingEducationProvider);
        }

        public async Task<EducationProviderResponse> GetByProfileId(int profileId)
        {
            var existingProfile = await _profileRepository.FindById(profileId);
            if (existingProfile == null)
                return new EducationProviderResponse($"Profile with id {profileId} not found");

            int educationProviderId = existingProfile.EducationProviderId;

            var existingEducationProvider = await _educationProviderRepository.FindById(educationProviderId);
            if (existingEducationProvider == null)
                return new EducationProviderResponse($"There is no education provider for profile {profileId}");
            return new EducationProviderResponse(existingEducationProvider);
        }

        public async Task<EducationProviderResponse> UpdateAsync(int id, EducationProvider educationProvider)
        {
            //buscamos
            var existingEducationProvider = await _educationProviderRepository.FindById(id);

            //si no encontramos
            if (existingEducationProvider == null)
                return new EducationProviderResponse($"EducationProvider with id: {id} not found");

            //intercambiamos con
            existingEducationProvider.Name = educationProvider.Name;
            existingEducationProvider.NumberOfCareers = educationProvider.NumberOfCareers;

            try
            {
                _educationProviderRepository.Update(existingEducationProvider);
                await _unitOfWork.CompleteAsync();

                return new EducationProviderResponse(existingEducationProvider);
            }
            catch(Exception ex)
            {
                return new EducationProviderResponse($"An error ocurred while updating educationProvider {ex.Message}");
            }


        }

       public async Task<EducationProviderResponse> DeleteAsync(int id)
        {
            var existingEducationProvider = await _educationProviderRepository.FindById(id);

            if (existingEducationProvider == null)
                return new EducationProviderResponse($"EducationProvider with id: {id} not found");

            try
            {
                _educationProviderRepository.Remove(existingEducationProvider);
                await _unitOfWork.CompleteAsync();

                return new EducationProviderResponse(existingEducationProvider);
            }
            catch(Exception ex)
            {
                return new EducationProviderResponse($"An error ocurred while deleting educationProvider {ex.Message}");
            }

        }
        /*
        public async Task<string> ReadPeriodInfo(int educationProviderId)
        {
            

        }*/
    }
}
