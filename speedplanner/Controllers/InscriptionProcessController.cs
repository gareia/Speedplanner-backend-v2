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
{/*

    [Route("/api/User/{userId}/[controller]")]
    public class InscriptionProcessController : Controller
    {
        private readonly IInscriptionProcessService _inscriptionProcessService;
        private readonly IMapper _mapper;

        public InscriptionProcessController(IInscriptionProcessService inscriptionProcessService, IMapper mapper)
        {
            _inscriptionProcessService = inscriptionProcessService;
            _mapper = mapper;
        }

        
        /*
        [HttpGet] //tal vez borrar
        public async Task<IEnumerable<InscriptionProcessResource>> GetAllAsync()
        {
            var inscriptionProcesses = await _inscriptionProcessService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<InscriptionProcess>, IEnumerable<InscriptionProcessResource>>(inscriptionProcesses);
            return resources;
        }

        [HttpGet]
        public async Task<IEnumerable<InscriptionProcessResource>> GetAllByUserIdAsync([FromRoute] int userId)
        {
            var inscriptionProcesses = await _inscriptionProcessService.ListByUserIdAsync(userId);
            var resources = _mapper
                .Map<IEnumerable<InscriptionProcess>, IEnumerable<InscriptionProcessResource>>(inscriptionProcesses);
            return resources;
        }

        [HttpGet("{inscriptionProcessId}")]
        public async Task<IActionResult> GetByIdAndUserIdAsync([FromRoute] int userId, int inscriptionProcessId)
        {
            var result = await _inscriptionProcessService.GetByIdAndUserIdAsync(userId, inscriptionProcessId);
            if (!result.Success)
                return BadRequest(result.Message);
            var inscriptionProcessResource = _mapper.Map<InscriptionProcess, InscriptionProcessResource>(result.Resource);
            //return Ok(inscriptionProcessResource);
            string info = await _inscriptionProcessService.ReadUserInfo(inscriptionProcessId);
            return Ok(info);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromRoute] int userId, [FromBody] SaveInscriptionProcessResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var inscriptionProcess = _mapper.Map<SaveInscriptionProcessResource, InscriptionProcess>(resource);
            var result = await _inscriptionProcessService.SaveAsync(userId, inscriptionProcess);

            if (!result.Success)
                return BadRequest(result.Message);

            var inscriptionProcessResource = _mapper.Map<InscriptionProcess, InscriptionProcessResource>(result.Resource);
            return Ok(inscriptionProcessResource);
        }

        //there is no http put method

        [HttpDelete("{inscriptionprocessId}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int userId, int inscriptionprocessId)
        {
            var result = await _inscriptionProcessService.DeleteAsync(userId, inscriptionprocessId);

            if (!result.Success)
                return BadRequest(result.Message);

            var inscriptionProcessResource = _mapper.Map<InscriptionProcess, InscriptionProcessResource>(result.Resource);
            return Ok(inscriptionProcessResource);
        }




    }*/
    
}
