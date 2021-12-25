using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JobJournal.Server.Data;
using JobJournal.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobJournal.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationStatusController : ControllerBase
    {
        private readonly IApplicationStatusRepository _repository;
        private readonly IMapper _mapper;

        public ApplicationStatusController(IApplicationStatusRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/applicationstatus/all
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ApplicationStatusDTO>>> GetAllApplicationStatuses()
        {
            try
            {
                return Ok(await _mapper.ProjectTo<ApplicationStatusDTO>(_repository.GetApplicationStatuses()).ToListAsync());
            }
            catch
            {
                // TODO: Log exception
                return BadRequest();
            }
        }

        // GET api/applicationstatus/3
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApplicationStatusDTO>> GetApplicationStatus(int id)
        {
            try
            {
                var status = await _repository.GetApplicationStatus(id);
                return Ok(_mapper.Map<ApplicationStatusDTO>(status));
            }
            catch
            {
                // TODO: Log exception
                return NotFound();
            }
        }
    }
}
