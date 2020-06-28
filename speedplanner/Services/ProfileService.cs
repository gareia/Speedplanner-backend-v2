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
    public class ProfileService : IProfileService
    {
        public readonly IProfileRepository _profileRepository;
        public readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public ProfileService(IProfileRepository profileRepository, IUnitOfWork unitOfWork,
            IUserRepository userRepository)
        {
            _profileRepository = profileRepository;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        //HELPFULL METHODS
        private async Task<User> FindUserById(int userId)
        {
            var existingUser = await _userRepository.FindById(userId);
            return existingUser;
        }

        private async Task<Profile> FindProfileById(int profileId)
        {
            var existingProfile = await _profileRepository.FindById(profileId);
            return existingProfile;
        }


        public async Task<ProfileResponse> SaveAsync(int userId, Profile profile)
        {
            //find user
            if (await FindUserById(userId) == null)
                return new ProfileResponse($"User with id: {userId} not found");

            //now add
            try
            {
                await _profileRepository.AddAsync(userId, profile);
                await _unitOfWork.CompleteAsync();
                return new ProfileResponse(profile);
            }
            catch (Exception ex)
            {
                return new ProfileResponse($"An error ocurred while saving profile: {ex.Message}");
            }
        }

        public async Task<ProfileResponse> GetByIdAndUserIdAsync(int userId, int id)
        {
            //find user
            if (await FindUserById(userId) == null)
                return new ProfileResponse($"User with id: {userId} not found");

            //find profile
            var existingProfile = await FindProfileById(id);
            if (existingProfile == null)
                return new ProfileResponse($"Profile  with id: {id} not found");
            return new ProfileResponse(existingProfile);
        }


        /*
        public async Task<ProfileResponse> DeleteAsync(int id)
        {
            var existingProfile = await _profileRepository.FindById(id);
            if (existingProfile == null)
                return new ProfileResponse("Profile not found");
            try
            {
                _profileRepository.Remove(existingProfile);
                await _unitOfWork.CompleteAsync();

                return new ProfileResponse(existingProfile);
            }
            catch (Exception ex)
            {
                return new ProfileResponse($"An error ocurred while deleting profile: {ex.Message}");
            }
        }

       
        public async Task<IEnumerable<Profile>> ListAsync()
        {
            return await _profileRepository.ListAsync();
        }
        */
        
        /*public async Task<UserResponse> UpdateAsync(int id, User user)
        {
            var existingUser = await _userRepository.FindById(id);
            if (existingUser == null)
                return new UserResponse("User not found");
            existingUser.Username = existingUser.Username;  
            existingUser.Email = existingUser.Email;
            existingUser.Password = existingUser.Password;
            try
            {
                _userRepository.Update(existingUser);
                await _unitOfWork.CompleteAsync();
                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error ocurred while updating user: {ex.Message}");
            }
        }*/
        /*
        public async Task<ProfileResponse> UpdateAsync(int id, Profile profile)
        {
            var existingProfile = await _profileRepository.FindById(id);
            if (existingProfile == null)
                return new ProfileResponse("Profile not found");

            existingProfile.Names = profile.Names;
            existingProfile.LastNames = profile.LastNames;
            existingProfile.Semester = profile.Semester;
            existingProfile.Gender = profile.Gender;

            try
            {
                _profileRepository.Update(existingProfile);
                await _unitOfWork.CompleteAsync();

                return new ProfileResponse(existingProfile);
            }
            catch (Exception ex)
            {
                return new ProfileResponse($"An error ocurred while updating profile: {ex.Message}");
            }
        }

        */
    }

}
