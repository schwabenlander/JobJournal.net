using JobJournal.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobJournal.Client.Services
{
    public interface ICompanyContactDataService
    {
        Task<PaginatedResultDTO<CompanyContactDTO>> GetCompanyContactsAsync(Guid companyId, int page = 1, int recordsPerPage = 20);

        Task<int> GetCompanyContactCountAsync(Guid companyId);

        Task<CompanyContactDTO> GetCompanyContactAsync(Guid id);

        Task<CompanyContactDTO> AddCompanyContactAsync(CompanyContactDTO companyContact);

        Task UpdateCompanyContactAsync(CompanyContactDTO companyContact);

        Task DeleteCompanyContactAsync(Guid id);
    }
}
