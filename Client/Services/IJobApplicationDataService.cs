using JobJournal.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobJournal.Client.Services
{
    public interface IJobApplicationDataService
    {
        Task<IEnumerable<ApplicationMethodDTO>> GetApplicationMethodsAsync();

        Task<IEnumerable<ApplicationStatusDTO>> GetApplicationStatusesAsync();

        Task<PaginatedResultDTO<JobApplicationDTO>> GetJobApplicationsAsync(Guid userId, int page = 1, int recordsPerPage = 20);

        Task<PaginatedResultDTO<JobApplicationDTO>> GetJobApplicationsByCompanyAsync(Guid companyId, int page = 1, int recordsPerPage = 20);

        Task<JobApplicationDTO> GetJobApplicationAsync(Guid id);

        Task<int> GetJobApplicationCountForUserAsync(Guid userId);

        Task<JobApplicationDTO> AddJobApplicationAsync(JobApplicationDTO jobApplication);

        Task UpdateJobApplicationAsync(JobApplicationDTO jobApplication);

        Task DeleteJobApplicationAsync(Guid id);
    }
}
