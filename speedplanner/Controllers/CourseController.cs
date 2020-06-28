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
    public class CourseController: Controller
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public CourseController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }
        [HttpGet("/api/User/{userId}/Course")]
        public async Task<IEnumerable<CourseResource>> GetAllByProfileIdAsync([FromRoute] int userId)
        {
            var courses = await _courseService.ListByProfileIdAsync(userId);
            var resources = _mapper
                .Map<IEnumerable<Course>, IEnumerable<CourseResource>>(courses);
            return resources;

        }

        [HttpGet("/api/EducationProvider/{educationProviderId}/Course")]
        public async Task<IEnumerable<CourseResource>> GetAllByEducationProviderIdAsync([FromRoute] int educationProviderId)
        {
            var courses = await _courseService.ListByEducationProviderIdAsync(educationProviderId);
            var resources = _mapper
                .Map<IEnumerable<Course>, IEnumerable<CourseResource>>(courses);
            return resources;
        }

        [HttpGet("/api/EducationProvider/{educationProviderId}/Course/{courseId}")]
        public async Task<IActionResult> GetByIdAndEducationProviderIdAsync([FromRoute] int educationProviderId, int courseId)
        {
            var result = await _courseService.GetByIdAndEducationProviderIdAsync(educationProviderId, courseId);
            if (!result.Success)
                return BadRequest(result.Message);
            var courseResource = _mapper.Map<Course, CourseResource>(result.Resource);
            return Ok(courseResource);
        }

        [HttpPost("/api/EducationProvider/{educationProviderId}/Course")] 
        public async Task<IActionResult> PostAsync([FromRoute] int educationProviderId, [FromBody] SaveCourseResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var course = _mapper.Map<SaveCourseResource, Course>(resource);
            var result = await _courseService.SaveAsync(educationProviderId, course);

            if (!result.Success)
                return BadRequest(result.Message);

            var courseResource = _mapper.Map<Course, CourseResource>(result.Resource);
            return Ok(courseResource);
        }

        [HttpPut("/api/EducationProvider/{educationProviderId}/Course/{courseId}")] 
        public async Task<IActionResult> PutAsync([FromRoute] int educationProviderId, int courseId, [FromBody] SaveCourseResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var course = _mapper.Map<SaveCourseResource, Course>(resource);
            var result = await _courseService.UpdateAsync(educationProviderId, courseId, course);

            if (!result.Success)
                return BadRequest(result.Message);

            var courseResource = _mapper.Map<Course, CourseResource>(result.Resource);
            return Ok(courseResource);
        }

        [HttpDelete("/api/EducationProvider/{educationProviderId}/Course/{courseId}")] 
        public async Task<IActionResult> DeleteAsync([FromRoute] int educationProviderId, int courseId)
        {
            var result = await _courseService.DeleteAsync(educationProviderId, courseId);

            if (!result.Success)
                return BadRequest(result.Message);

            var courseResource = _mapper.Map<Course, CourseResource>(result.Resource);
            return Ok(courseResource);
        }
    }
}
