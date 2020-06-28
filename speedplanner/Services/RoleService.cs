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
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public RoleService(IRoleRepository roleRepository, IUnitOfWork unitOfWork,
            IUserRepository userRepository)
        {
            _roleRepository = roleRepository;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        //HELPFULL METHODS
        private async Task<User> FindUserById(int userId)
        {
            var existingUser = await _userRepository.FindById(userId);
            return existingUser;
        }

        private async Task<Role> FindRoleById(int roleId)
        {
            var existingRole = await _roleRepository.FindById(roleId);
            return existingRole;
        }


        public async Task<RoleResponse> SaveAsync(int userId, Role role)
        {
            //find user
            if (await FindUserById(userId) == null)
                return new RoleResponse($"User with id: {userId} not found");

            //now add
            try
            {
                await _roleRepository.AddAsync(userId, role);
                await _unitOfWork.CompleteAsync();

                return new RoleResponse(role);
            }
            catch (Exception ex)
            {
                return new RoleResponse($"An error ocurred while saving role: {ex.Message}");
            }

        }
        public async Task<RoleResponse> GetByIdAndUserIdAsync(int userId, int roleId)
        {
            //find user
            if (await FindUserById(userId) == null)
                return new RoleResponse($"User with id: {userId} not found");

            //find role
            var existingRole = await FindRoleById(roleId);

            if (existingRole == null)
                return new RoleResponse($"Role with id: {roleId} not found");

            return new RoleResponse(existingRole);
        }

        /*
        public async Task<RoleResponse> DeleteAsync(int id)
        {
            var existingRole = await _roleRepository.FindById(id);
            if (existingRole == null)
                return new RoleResponse("Role not found");
            try
            {
                _roleRepository.Remove(existingRole);
                await _unitOfWork.CompleteAsync();

                return new RoleResponse(existingRole);
            }
            catch (Exception ex)
            {
                return new RoleResponse($"An error ocurred while deleting role: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Role>> ListAsync()
        {
            return await _roleRepository.ListAsync();
        }

        public async Task<IEnumerable<Role>> ListByUserIdAsync(int userId)
        {
            return await _roleRepository.ListByUserIdAsync(userId);
        }

       
        public async Task<RoleResponse> UpdateAsync(int id, int type)
        {
            var existingRole = await _roleRepository.FindById(id);
            if (existingRole == null)
                return new RoleResponse("Role not found");

            existingRole.Type = type;

            try
            {
                _roleRepository.Update(existingRole);
                await _unitOfWork.CompleteAsync();

                return new RoleResponse(existingRole);
            }
            catch (Exception ex)
            {
                return new RoleResponse($"An error ocurred while updating role: {ex.Message}");
            }
        }*/

    }
}
