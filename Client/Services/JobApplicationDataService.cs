using JobJournal.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace JobJournal.Client.Services
{
    public class JobApplicationDataService : IJobApplicationDataService
    {
        private readonly HttpClient _httpClient;

        public JobApplicationDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<JobApplicationDTO> AddJobApplicationAsync(JobApplicationDTO jobApplication)
        {
            var response = await _httpClient.PostAsJsonAsync("api/jobapplication", jobApplication);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<JobApplicationDTO>();
            }

            return null;
        }

        public async Task DeleteJobApplicationAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"api/jobapplication/{id}");
        }

        public async Task<IEnumerable<ApplicationMethodDTO>> GetApplicationMethodsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ApplicationMethodDTO>>($"api/applicationmethod/all");
        }

        public async Task<IEnumerable<ApplicationStatusDTO>> GetApplicationStatusesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ApplicationStatusDTO>>($"api/applicationstatus/all");
        }

        public async Task<JobApplicationDTO> GetJobApplicationAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<JobApplicationDTO>($"api/jobapplication/{id}");
        }

        public async Task<int> GetJobApplicationCountForUserAsync(Guid userId)
        {
            return await _httpClient.GetFromJsonAsync<int>($"api/jobapplication/user/{userId}/count");
        }

        public async Task<PaginatedResultDTO<JobApplicationDTO>> GetJobApplicationsAsync(Guid userId, int page = 1, int recordsPerPage = 10)
        {
            return await _httpClient.GetFromJsonAsync<PaginatedResultDTO<JobApplicationDTO>>($"api/jobapplication/user/{userId}?Page={page}&RecordsPerPage={recordsPerPage}");
        }

        public async Task<PaginatedResultDTO<JobApplicationDTO>> GetJobApplicationsByCompanyAsync(Guid companyId, int page = 1, int recordsPerPage = 20)
        {
            return await _httpClient.GetFromJsonAsync<PaginatedResultDTO<JobApplicationDTO>>($"api/jobapplication/company/{companyId}?Page={page}&RecordsPerPage={recordsPerPage}");
        }

        public async Task UpdateJobApplicationAsync(JobApplicationDTO jobApplication)
        {
            await _httpClient.PutAsJsonAsync($"api/jobapplication/{jobApplication.Id}", jobApplication);
        }
    }
}
