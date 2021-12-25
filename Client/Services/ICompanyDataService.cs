using JobJournal.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobJournal.Client.Services
{
    public interface ICompanyDataService
    {
        Task<int> GetCompanyCountForUserAsync(Guid userId);
        Task<PaginatedResultDTO<CompanyDTO>> GetCompaniesAsync(Guid userId, int page = 1, int recordsPerPage = 20);

        Task<CompanyDTO> GetCompanyAsync(Guid id);

        Task<CompanyDTO> AddCompanyAsync(CompanyDTO company);

        Task UpdateCompanyAsync(CompanyDTO company);

        Task DeleteCompanyAsync(Guid id);
    }
}
