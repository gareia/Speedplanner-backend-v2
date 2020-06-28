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
    public class SectionScheduleService : ISectionScheduleService
    {
        private readonly ISectionScheduleRepository _sectionScheduleRepository;
        public readonly IUnitOfWork _unitOfWork;
        private readonly ISectionRepository _sectionRepository;

        public SectionScheduleService(ISectionScheduleRepository sectionScheduleRepository,
            IUnitOfWork unitOfWork, ISectionRepository sectionRepository)
        {
            _sectionScheduleRepository = sectionScheduleRepository;
            _unitOfWork = unitOfWork;
            _sectionRepository = sectionRepository;
        }

        //HELPFULL METHODS
        private async Task<Section> FindSectionById(int sectionId)
        {
            var existingSection = await _sectionRepository.FindById(sectionId);
            return existingSection;
        }

        private async Task<SectionSchedule> FindSectionScheduleById(int sectionScheduleId)
        {
            var existingSectionSchedule = await _sectionScheduleRepository.FindById(sectionScheduleId);
            return existingSectionSchedule;
        }

        //crud methods
        public async Task<IEnumerable<SectionSchedule>> ListBySectionIdAsync(int sectionId)
        {
            return await _sectionScheduleRepository.ListBySectionIdAsync(sectionId);
        }


        public async Task<SectionScheduleResponse> SaveAsync(int sectionId, SectionSchedule sectionSchedule)
        {
            //find section
            if (await FindSectionById(sectionId) == null)
                return new SectionScheduleResponse($"Section with id: {sectionId} not found");

            //now add
            try
            {
                await _sectionScheduleRepository.AddAsync(sectionId, sectionSchedule);
                await _unitOfWork.CompleteAsync();

                return new SectionScheduleResponse(sectionSchedule);
            }
            catch (Exception ex)
            {
                return new SectionScheduleResponse($"An error ocurred while saving the sectionSchedule: {ex.Message}");
            }
        }

        public async Task<SectionScheduleResponse> GetByIdAndSectionIdAsync(int sectionId, int id)
        {
            //find section
            if (await FindSectionById(sectionId) == null)
                return new SectionScheduleResponse($"Section with id: {sectionId} not found");

            //find sectionSchedule
            var existingSectionSchedule = await FindSectionScheduleById(id);

            if (existingSectionSchedule == null)
                return new SectionScheduleResponse($"Learning program with id: {id} not found");

            return new SectionScheduleResponse(existingSectionSchedule);

        }
        /*
        public async Task<SectionScheduleResponse> UpdateAsync(int id, SectionSchedule sectionSchedule, int sectionScheduleId)
        {
            var existingSectionSchedule = await _sectionScheduleRepository.FindByIdAndSectionId(id, sectionScheduleId);

            if (existingSectionSchedule == null)
                return new SectionScheduleResponse("SectionSchedule not found");

            existingSectionSchedule.SectionName = existingSectionSchedule.SectionName;
            existingSectionSchedule.StartTime = existingSectionSchedule.StartTime;
            existingSectionSchedule.EndTime = existingSectionSchedule.EndTime;
            existingSectionSchedule.NumberOfHours = existingSectionSchedule.NumberOfHours;
            existingSectionSchedule.Day = existingSectionSchedule.Day;

            try
            {
                _sectionScheduleRepository.Update(existingSectionSchedule);
                await _unitOfWork.CompleteAsync();

                return new SectionScheduleResponse(existingSectionSchedule);
            }
            catch (Exception ex)
            {
                return new SectionScheduleResponse($"An error ocurred while updating sectionSchedule: {ex.Message}");
            }
        }

        public async Task<SectionScheduleResponse> DeleteAsync(int id, int sectionId)
        {
            var existingSectionSchedule = await _sectionScheduleRepository.FindByIdAndSectionId(id, sectionId);

            if (existingSectionSchedule == null)
                return new SectionScheduleResponse("SectionSchedule not found");

            try
            {
                _sectionScheduleRepository.Remove(existingSectionSchedule);
                await _unitOfWork.CompleteAsync();

                return new SectionScheduleResponse(existingSectionSchedule);
            }
            catch (Exception ex)
            {
                return new SectionScheduleResponse($"An error ocurred while deleting sectionSchedule: {ex.Message}");
            }
        }*/
    }
}
