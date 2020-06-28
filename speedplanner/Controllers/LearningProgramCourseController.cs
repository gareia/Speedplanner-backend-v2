using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using speedplanner.Domain.Models;
using speedplanner.Domain.Services;
using speedplanner.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Controllers
{
    
    public class LearningProgramCourseController : Controller
    {

        private readonly ILearningProgramCourseService _learningProgramCourseService;
        private readonly IMapper _mapper;

        public LearningProgramCourseController(ILearningProgramCourseService learningProgramCourseService, IMapper mapper)
        {
            _learningProgramCourseService = learningProgramCourseService;
            _mapper = mapper;
        }

        //brings lpid and cid, similar to course controller method
        public async Task<IEnumerable<LearningProgramCourseResource>> GetAllByProfileIdAsync([FromRoute] int userId)
        {
            var learningProgramCourses = await _learningProgramCourseService.ListByProfileIdAsync(userId);
            var resources = _mapper
                .Map<IEnumerable<LearningProgramCourse>, IEnumerable<LearningProgramCourseResource>>(learningProgramCourses);
            return resources;

        }



        [HttpGet("/learning-program-courses")]
        public async Task<IEnumerable<LearningProgramCourseResource>> GetAllAsync()
        {
            var learningProgramCourses = await _learningProgramCourseService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<LearningProgramCourse>, IEnumerable<LearningProgramCourseResource>>(learningProgramCourses);
            return resources;
        }

        //Peude que este mal el service de muchos a muchos: by learningprogramid
        [HttpGet("/learning-programs/{learningProgramId}/courses")]
        public async Task<IEnumerable<LearningProgramCourseResource>> GetAllByLearningProgramIdAsync(int learningProgramId)
        {
            var learningProgramCourses = await _learningProgramCourseService.ListByLearningProgramIdAsync(learningProgramId);
            var resources = _mapper
                .Map<IEnumerable<LearningProgramCourse>, IEnumerable<LearningProgramCourseResource>>(learningProgramCourses);
            return resources;
        }


        [HttpPost("/learning-programs/{learningProgramId}/courses/{courseId}")]
        public async Task<IActionResult> AssignLearningProgram(int learningProgramId, int courseId)
        {

            var result = await _learningProgramCourseService.AssignLearningProgramCourseAsync(learningProgramId, courseId);
            if (!result.Success)
                return BadRequest(result.Message);

            var courseResource = _mapper.Map<Course, CourseResource>(result.Resource.Course);
            return Ok(courseResource);

        }

        [HttpDelete("/learning-programs/{learningProgramId}/courses/{courseId}")]
        public async Task<IActionResult> UnassignLearningProgram(int learningProgramId, int courseId)
        {

            var result = await _learningProgramCourseService.UnassignLearningProgramCourseAsync(learningProgramId, courseId);
            if (!result.Success)
                return BadRequest(result.Message);

            var courseResource = _mapper.Map<Course, CourseResource>(result.Resource.Course);
            return Ok(courseResource);

        }



    }
    
        
}
