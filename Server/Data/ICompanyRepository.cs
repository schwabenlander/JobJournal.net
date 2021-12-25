using JobJournal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobJournal.Server.Data
{
    public interface ICompanyRepository
    {
        Task<Company> GetCompany(Guid companyId);
        IQueryable<Company> GetCompaniesForUser(Guid userId);
        Task<Company> AddCompany(Company company);
        Task<Company> UpdateCompany(Company company);
        Task DeleteCompany(Guid companyId);
        Task<int> GetCompanyCountForUser(Guid userId);
    }
}
