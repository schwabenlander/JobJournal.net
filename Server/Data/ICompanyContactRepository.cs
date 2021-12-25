using JobJournal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobJournal.Server.Data
{
    public interface ICompanyContactRepository
    {
        CompanyContact GetCompanyContact(Guid contactId);
        IQueryable<CompanyContact> GetContactsForCompany(Guid companyId);
        Task<CompanyContact> AddCompanyContact(CompanyContact companyContact);
        Task<CompanyContact> UpdateCompanyContact(CompanyContact companyContact);
        Task<int> GetCompanyContactCount(Guid companyId);
        Task DeleteCompanyContact(Guid contactId);
    }
}
