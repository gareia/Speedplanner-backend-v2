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
    public class SectionController: Controller
    {
            private readonly ISectionService _sectionService;
            private readonly IMapper _mapper;

            public SectionController(ISectionService sectionService, IMapper mapper)
            {
                _sectionService = sectionService;
                _mapper = mapper;
            }

            [HttpGet("api/User/{userId}/Course/{courseId}/Section")]
            public async Task<IEnumerable<SectionResource>> GetAllByCourseIdAsync(int courseId)
            {
                var sections = await _sectionService.ListByCourseIdAsync(courseId);
                var resources = _mapper.Map<IEnumerable<Section>, IEnumerable<SectionResource>>(sections);
                return resources;
            }

            [HttpPost("api/User/{userId}/Course/{courseId}/Section")]
            public async Task<IActionResult> PostAsync(int courseId, [FromBody] SaveSectionResource resource)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.GetErrorMessages());
                var section = _mapper.Map<SaveSectionResource, Section>(resource);
                var result = await _sectionService.SaveAsync(courseId, section);
                if (!result.Success)
                    return BadRequest(result.Message);
                var sectionResource = _mapper.Map<Section, SectionResource>(result.Resource);
                return Ok(sectionResource);
            }

            [HttpGet("api/User/{userId}/Course/{courseId}/Section/{sectionId}")]
            public async Task<IActionResult> GetByIdAndCourseIdAsync([FromRoute] int courseId, [FromRoute] int sectionId)
            {
                var result = await _sectionService.GetByIdAndCourseIdAsync(courseId, sectionId);
                if (!result.Success)
                    return BadRequest(result.Message);
                var sectionResource = _mapper.Map<Section, SectionResource>(result.Resource);
                return Ok(sectionResource);
            }

        /*
            [HttpPut("{id}")]
            public async Task<IActionResult> PutAsync(int sectionId, [FromBody] SaveSectionResource resource)
            {
                var section = _mapper.Map<SaveSectionResource, Section>(resource);
                var result = await _sectionService.UpdateAsync(sectionId, section);
                if (!result.Success)
                    return BadRequest(result.Message);
                var sectionResource = _mapper.Map<Section, SectionResource>(result.Resource);
                return Ok(sectionResource);

            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteAsync(int sectionId)
            {
                var result = await _sectionService.DeleteAsync(sectionId);

                if (!result.Success)
                    return BadRequest(result.Message);
                var sectionResource = _mapper.Map<Section, SectionResource>(result.Resource);
                return Ok(sectionResource);
            }
            */
    }
}
