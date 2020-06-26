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
    [Route("/api/User/{userId}/InscriptionProcess/{inscriptionProcessId}/[controller]")]
    public class CourseController: Controller
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public CourseController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CourseResource>> GetAllByInscriptionProcessIdAsync([FromRoute] int inscriptionProcessId)
        {
            var courses = await _courseService.ListByInscriptionProcessIdAsync(inscriptionProcessId);
            var resources = _mapper
                .Map<IEnumerable<Course>, IEnumerable<CourseResource>>(courses);
            return resources;
        }

        [HttpGet("{courseId}")]
        public async Task<IActionResult> GetByIdAndInscriptionProcessIdAsync([FromRoute] int inscriptionProcessId, int courseId)
        {
            var result = await _courseService.GetByIdAndInscriptionProcessIdAsync(inscriptionProcessId, courseId);
            if (!result.Success)
                return BadRequest(result.Message);
            var courseResource = _mapper.Map<Course, CourseResource>(result.Resource);
            return Ok(courseResource);
        }

        [HttpPost] //ESTO NO DEBERIA ESTAR ACAAA o AL MENOS NO PARA UN USUARIO
        public async Task<IActionResult> PostAsync([FromRoute] int inscriptionProcessId, [FromBody] SaveCourseResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var course = _mapper.Map<SaveCourseResource, Course>(resource);
            var result = await _courseService.SaveAsync(inscriptionProcessId, course);

            if (!result.Success)
                return BadRequest(result.Message);

            var courseResource = _mapper.Map<Course, CourseResource>(result.Resource);
            return Ok(courseResource);
        }

        [HttpPut("{courseId}")] //TAMPOCO
        public async Task<IActionResult> PutAsync([FromRoute] int inscriptionProcessId, int courseId, [FromBody] SaveCourseResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var course = _mapper.Map<SaveCourseResource, Course>(resource);
            var result = await _courseService.UpdateAsync(inscriptionProcessId, courseId, course);

            if (!result.Success)
                return BadRequest(result.Message);

            var courseResource = _mapper.Map<Course, CourseResource>(result.Resource);
            return Ok(courseResource);
        }

        [HttpDelete("{courseId}")] //TAMPOCO
        public async Task<IActionResult> DeleteAsync([FromRoute] int inscriptionProcessId, int courseId)
        {
            var result = await _courseService.DeleteAsync(inscriptionProcessId, courseId);

            if (!result.Success)
                return BadRequest(result.Message);

            var courseResource = _mapper.Map<Course, CourseResource>(result.Resource);
            return Ok(courseResource);
        }
    }
}
