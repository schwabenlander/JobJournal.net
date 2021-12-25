using JobJournal.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace JobJournal.Client.Services
{
    public class CompanyDataService : ICompanyDataService
    {
        private readonly HttpClient _httpClient;

        public CompanyDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PaginatedResultDTO<CompanyDTO>> GetCompaniesAsync(Guid userId, int page = 1, int recordsPerPage = 10)
        {
            return await _httpClient.GetFromJsonAsync<PaginatedResultDTO<CompanyDTO>>($"api/company/all/{userId}?Page={page}&RecordsPerPage={recordsPerPage}");
        }

        public async Task<CompanyDTO> GetCompanyAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<CompanyDTO>($"api/company/{id}");
        }

        public async Task<CompanyDTO> AddCompanyAsync(CompanyDTO company)
        {
            var response = await _httpClient.PostAsJsonAsync("api/company", company);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<CompanyDTO>();
            }

            return null;
        }

        public async Task UpdateCompanyAsync(CompanyDTO company)
        {
            await _httpClient.PutAsJsonAsync($"api/company/{company.Id}", company);
        }

        public async Task DeleteCompanyAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"api/company/{id}");
        }

        public async Task<int> GetCompanyCountForUserAsync(Guid userId)
        {
            return await _httpClient.GetFromJsonAsync<int>($"api/company/all/{userId}/count");
        }
    }
}
