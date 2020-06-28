using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    
    //[Route("/api/[controller]")]
    public class EducationProviderController : Controller
    {

        private readonly IEducationProviderService _educationProviderService;
        private readonly IMapper _mapper;
        
        public EducationProviderController(IEducationProviderService educationProviderService, IMapper mapper)
        {
            _educationProviderService = educationProviderService;
            _mapper = mapper;
        }

        [HttpGet("api/User/{userId}/Role/Profile/EducationProvider")]
        public async Task<IActionResult> GetByProfileId(int userId) //Same that profileId
        {
            var result = await _educationProviderService.GetByProfileId(userId);
            if (!result.Success)
                return BadRequest(result.Message);
            var educationProviderResource = _mapper.Map<EducationProvider, EducationProviderResource>(result.Resource);
            return Ok(educationProviderResource);
        }

        [HttpGet("/api/EducationProvider")]
        public async Task<IEnumerable<EducationProviderResource>> GetAllAsync()
        {
            var educationProviders = await _educationProviderService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<EducationProvider>, IEnumerable<EducationProviderResource>>(educationProviders);
            return resources;
        }


        [HttpGet("/api/EducationProvider/{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _educationProviderService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var educationProviderResource = _mapper.Map<EducationProvider, EducationProviderResource>(result.Resource);
            return Ok(educationProviderResource);
        }

        [HttpPost("/api/EducationProvider")]
        public async Task<IActionResult> PostAsync([FromBody] SaveEducationProviderResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            
            var educationProvider = _mapper.Map<SaveEducationProviderResource, EducationProvider>(resource);
            var result = await _educationProviderService.SaveAsync(educationProvider);

            if (!result.Success)
                return BadRequest(result.Message);

            var educationProviderResource = _mapper.Map<EducationProvider, EducationProviderResource>(result.Resource);
            return Ok(educationProviderResource);
        }

        [HttpPut("/api/EducationProvider/{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveEducationProviderResource resource)
        {
            var educationProvider = _mapper.Map<SaveEducationProviderResource, EducationProvider>(resource);
            var result = await _educationProviderService.UpdateAsync(id, educationProvider);

            if (!result.Success)
                return BadRequest(result.Message);

            var educationProviderResource = _mapper.Map<EducationProvider, EducationProviderResource>(result.Resource);
            return Ok(educationProviderResource);
        }

        [HttpDelete("/api/EducationProvider/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _educationProviderService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var educationProviderResource = _mapper.Map<EducationProvider, EducationProviderResource>(result.Resource);
            return Ok(educationProviderResource);
        }
    }

}
