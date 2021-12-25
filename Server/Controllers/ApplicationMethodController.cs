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
    public class ApplicationMethodController : ControllerBase
    {
        private readonly IApplicationMethodRepository _repository;
        private readonly IMapper _mapper;

        public ApplicationMethodController(IApplicationMethodRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/applicationmethod/all
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ApplicationMethodDTO>>> GetAllApplicationMethods()
        {
            try
            {
                var applicationMethods = _repository.GetApplicationMethods();
                return Ok(await _mapper.ProjectTo<ApplicationMethodDTO>(applicationMethods).ToListAsync());
            }
            catch
            {
                // TODO: Log exception
                return BadRequest();
            }
        }

        // GET api/applicationmethod/2
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApplicationMethodDTO>> GetApplicationMethod(int id)
        {
            try
            {
                var method = await _repository.GetApplicationMethod(id);
                return Ok(_mapper.Map<ApplicationMethodDTO>(method));
            }
            catch
            {
                // TODO: Log exception
                return NotFound();
            }
        }
    }
}
