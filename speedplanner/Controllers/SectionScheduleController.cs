using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using speedplanner.Domain.Models;
using speedplanner.Domain.Services;
using speedplanner.Extensions;
using speedplanner.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Controllers
{
    public class SectionScheduleController: Controller
    {
            private readonly ISectionScheduleService _sectionScheduleService;
            private readonly IMapper _mapper;

            public SectionScheduleController(ISectionScheduleService sectionScheduleService, IMapper mapper)
            {
                _sectionScheduleService = sectionScheduleService;
                _mapper = mapper;
            }

            [HttpGet("api/User/{userId}/Course/{courseId}/Section/{sectionId}/SectionSchedule/{sectionScheduleId}")]
            public async Task<IActionResult> GetSectionScheduleBySectionIdAsync(int sectionId, int sectionScheduleId)
            {
                var result = await _sectionScheduleService.GetByIdAndSectionIdAsync(sectionId, sectionScheduleId);
                if (!result.Success)
                    return BadRequest(result.Message);
                var sectionScheduleResource = _mapper.Map<SectionSchedule, SectionScheduleResource>(result.Resource);
                return Ok(sectionScheduleResource);
            }

            [HttpGet("api/User/{userId}/Course/{courseId}/Section/{sectionId}/SectionSchedule")]
            public async Task<IEnumerable<SectionScheduleResource>> GetAllSectionScheduleBySectionIdAsync(int sectionId)
            {
            var sectionSchedules = await _sectionScheduleService.ListBySectionIdAsync(sectionId);
                var resources = _mapper.
                    Map<IEnumerable<SectionSchedule>, IEnumerable<SectionScheduleResource>>(sectionSchedules);
                return resources;
            }

            [HttpPost("api/User/{userId}/Course/{courseId}/Section/{sectionId}/SectionSchedule")]
            public async Task<IActionResult> PostAsync(int sectionId, [FromBody] SaveSectionScheduleResource resource)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.GetErrorMessages());
                var sectionSchedule = _mapper.Map<SaveSectionScheduleResource, SectionSchedule>(resource);
                var result = await _sectionScheduleService.SaveAsync(sectionId, sectionSchedule);

                if (!result.Success)
                    return BadRequest(result.Message);

                var sectionScheduleResource = _mapper.Map<SectionSchedule, SectionScheduleResource>(result.Resource);
                return Ok(sectionScheduleResource);
            }
        
    }
}
