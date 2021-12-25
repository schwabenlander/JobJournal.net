using JobJournal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobJournal.Server.Data
{
    public interface IJobApplicationRepository
    {
        JobApplication GetJobApplication(Guid applicationId);
        IQueryable<JobApplication> GetJobApplicationsForUser(Guid userId);
        IQueryable<JobApplication> GetJobApplicationsForCompany(Guid companyId);
        Task<JobApplication> AddJobApplication(JobApplication application);
        Task<JobApplication> UpdateJobApplication(JobApplication application);
        Task DeleteJobApplication(Guid applicationId);
        Task<int> GetJobApplicationCountForUser(Guid userId);
    }
}
