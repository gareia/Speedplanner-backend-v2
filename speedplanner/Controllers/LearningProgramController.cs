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
    
    [Route("/api/EducationProvider/{educationProviderId}/[controller]")]
    public class LearningProgramController : Controller
    {
        private readonly ILearningProgramService _learningProgramService;
        private readonly IMapper _mapper;

        public LearningProgramController(ILearningProgramService learningProgramService, IMapper mapper)
        {
            _learningProgramService = learningProgramService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<LearningProgramResource>> GetAllByEducationProviderIdAsync([FromRoute] int educationProviderId)
        {
            var learningPrograms = await _learningProgramService.ListByEducationProviderIdAsync(educationProviderId);
            var resources = _mapper
                .Map<IEnumerable<LearningProgram>, IEnumerable<LearningProgramResource>>(learningPrograms);
            return resources;
        }

        [HttpGet("{learningProgramId}")]
        public async Task<IActionResult> GetByIdAndEducationProviderIdAsync([FromRoute] int educationProviderId, int learningProgramId)
        {
            var result = await _learningProgramService.GetByIdAndEducationProviderIdAsync(educationProviderId, learningProgramId);
            if (!result.Success)
                return BadRequest(result.Message);
            var learningProgramResource = _mapper.Map<LearningProgram, LearningProgramResource>(result.Resource);
            return Ok(learningProgramResource);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromRoute] int educationProviderId, [FromBody] SaveLearningProgramResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var learningProgram = _mapper.Map<SaveLearningProgramResource, LearningProgram>(resource);
            var result = await _learningProgramService.SaveAsync(educationProviderId, learningProgram);

            if (!result.Success)
                return BadRequest(result.Message);

            var learningProgramResource = _mapper.Map<LearningProgram, LearningProgramResource>(result.Resource);
            return Ok(learningProgramResource);
        }

        [HttpPut("{learningProgramId}")]
        public async Task<IActionResult> PutAsync([FromRoute] int educationProviderId, int learningProgramId, [FromBody] SaveLearningProgramResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var learningProgram = _mapper.Map<SaveLearningProgramResource, LearningProgram>(resource);
            var result = await _learningProgramService.UpdateAsync(educationProviderId, learningProgramId, learningProgram);

            if (!result.Success)
                return BadRequest(result.Message);

            var learningProgramResource = _mapper.Map<LearningProgram, LearningProgramResource>(result.Resource);
            return Ok(learningProgramResource);
        }

        [HttpDelete("{learningProgramId}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int educationProviderId, int learningProgramId)
        {
            var result = await _learningProgramService.DeleteAsync(educationProviderId, learningProgramId);

            if (!result.Success)
                return BadRequest(result.Message);

            var learningProgramResource = _mapper.Map<LearningProgram, LearningProgramResource>(result.Resource);
            return Ok(learningProgramResource);
        }
    }
    
}
