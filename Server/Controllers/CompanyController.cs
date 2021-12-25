using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JobJournal.Server.Data;
using JobJournal.Server.Utilities;
using JobJournal.Shared;
using JobJournal.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobJournal.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _repository;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("all/{userId:Guid}/count")]
        public async Task<ActionResult<int>> GetCompanyCountForUser(Guid userId)
        {
            return Ok(await _repository.GetCompanyCountForUser(userId));
        }

        // GET: api/company/all/9b27e7b5-1acf-42c8-919a-6394fd1ddfe8?Page=2&RecordsPerPage=20
        [HttpGet("all/{userId:Guid}")]
        public async Task<ActionResult<PaginatedResultDTO<CompanyDTO>>> GetAllCompanies([FromRoute] Guid userId, [FromQuery] PaginationDTO paginationDTO)
        {
            try
            {
                var companies = _repository.GetCompaniesForUser(userId).OrderBy(c => c.CompanyName);

                var results = await _mapper.ProjectTo<CompanyDTO>(companies.Paginate(paginationDTO)).ToListAsync();

                var response = new PaginatedResultDTO<CompanyDTO>
                {
                    Results = results,
                    CurrentPage = paginationDTO.Page,
                    RecordsPerPage = paginationDTO.RecordsPerPage,
                    TotalRecords = await companies.CountAsync()
                };

                response.TotalPages = (int)Math.Ceiling((decimal)response.TotalRecords / (decimal)response.RecordsPerPage);

                return Ok(response);
            }
            catch
            {
                // TODO: Log exception
                return BadRequest();
            }
        }

        // GET api/company/ad94a572-5104-4303-82f7-fac0a7d06897
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<CompanyDTO>> GetCompany(Guid id)
        {
            try
            {
                var company = await _repository.GetCompany(id);
                return Ok(_mapper.Map<CompanyDTO>(company));
            }
            catch
            {
                // TODO: Log exception
                return NotFound();
            }
        }

        // POST api/company
        [HttpPost]
        public async Task<ActionResult<CompanyDTO>> AddCompany([FromBody] CompanyDTO companyDTO)
        {
            try
            {
                var company = _mapper.Map<Company>(companyDTO);
                var newCompany = await _repository.AddCompany(company);

                return CreatedAtAction(nameof(GetCompany), new { id = newCompany.Id }, _mapper.Map<CompanyDTO>(newCompany));
            }
            catch
            {
                // TODO: Log exception
                return BadRequest();
            }
        }

        // PUT api/company/ad94a572-5104-4303-82f7-fac0a7d06897
        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateCompany(Guid id, [FromBody] CompanyDTO companyDTO)
        {
            if (id != companyDTO.Id)
            {
                return BadRequest();
            }

            try
            {
                var company = _mapper.Map<Company>(companyDTO);
                await _repository.UpdateCompany(company);

                return NoContent();
            }
            catch
            {
                // TODO: Log exception
                return NotFound();
            }
        }

        // DELETE api/company/ad94a572-5104-4303-82f7-fac0a7d06897
        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteCompany(Guid id)
        {
            try
            {
                await _repository.DeleteCompany(id);
                return NoContent();
            }
            catch
            {
                // TODO: Log exception
                return BadRequest();
            }
        }
    }
}
