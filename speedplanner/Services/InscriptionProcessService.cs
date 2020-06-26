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
    public class InscriptionProcessService : IInscriptionProcessService
    {
        private readonly IInscriptionProcessRepository _inscriptionProcessRepository;
        public readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        //CONSTRUCTOR
        public InscriptionProcessService(IInscriptionProcessRepository inscriptionProcessRepository, IUnitOfWork unitOfWork,
            IUserRepository userRepository)
        {
            _inscriptionProcessRepository = inscriptionProcessRepository;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        //HELPFULL METHODS
        private async Task<User> FindUserById(int userId)
        {
            var existingUser = await _userRepository.FindById(userId);
            return existingUser;
        }

        private async Task<InscriptionProcess> FindInscriptionProcessById(int inscriptionProcessId)
        {
            var existingInscriptionProcess = await _inscriptionProcessRepository.FindByIdAsync(inscriptionProcessId);
            return existingInscriptionProcess;
        }

        //CRUD METHODS

        //Create---------
        public async Task<InscriptionProcessResponse> SaveAsync(int userId, InscriptionProcess inscriptionProcess)
        {
            //find user
            if (await FindUserById(userId) == null)
                return new InscriptionProcessResponse($"User with id: {userId} not found");

            //now add
            try
            {
                await _inscriptionProcessRepository.AddAsync(userId, inscriptionProcess);
                await _unitOfWork.CompleteAsync();

                return new InscriptionProcessResponse(inscriptionProcess);

            }
            catch(Exception ex)
            {
                return new InscriptionProcessResponse($"An error ocurred while saving the inscriptionProcess: {ex.Message}");
            }
        }

        //GetByUserId---------
        public async Task<IEnumerable<InscriptionProcess>> ListByUserIdAsync(int userId)
        {
            return await _inscriptionProcessRepository.ListByUserIdAsync(userId);
        }

        //GetByInscriptionProcessId&UserId---------
        public async Task<InscriptionProcessResponse> GetByIdAndUserIdAsync(int userId, int inscriptionProcessId)
        {
            //find user
            if (await FindUserById(userId) == null)
                return new InscriptionProcessResponse($"User with id: {userId} not found");

            //find inscription process
            var existingInscriptionProcess = await FindInscriptionProcessById(inscriptionProcessId);

            if (existingInscriptionProcess == null)
                return new InscriptionProcessResponse($"Inscription process with id: {inscriptionProcessId} not found");

            return new InscriptionProcessResponse(existingInscriptionProcess);
        }

        //Delete---------
        public async Task<InscriptionProcessResponse> DeleteAsync(int userId, int inscriptionProcessId)
        {
            //find user
            if (await FindUserById(userId) == null)
                return new InscriptionProcessResponse($"User with id: {userId} not found");

            //find inscription process
            var existingInscriptionProcess = await FindInscriptionProcessById(inscriptionProcessId);

            if (existingInscriptionProcess == null)
                return new InscriptionProcessResponse($"Inscription process with id: {inscriptionProcessId} not found");

            //now delete
            try
            {
                _inscriptionProcessRepository.Remove(existingInscriptionProcess);
                await _unitOfWork.CompleteAsync();

                return new InscriptionProcessResponse(existingInscriptionProcess);
            }
            catch(Exception ex)
            {
                return new InscriptionProcessResponse($"An error ocurred while deleting inscriptionProcess {ex.Message}");
            }
        }

        /*
       public async Task<IEnumerable<InscriptionProcess>> ListAsync()
       {
           return await _inscriptionProcessRepository.ListAsync();
       }*/
    }
}
