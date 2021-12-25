using JobJournal.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace JobJournal.Client.Services
{
    public class CompanyContactDataService : ICompanyContactDataService
    {
        private readonly HttpClient _httpClient;

        public CompanyContactDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CompanyContactDTO> AddCompanyContactAsync(CompanyContactDTO companyContact)
        {
            var response = await _httpClient.PostAsJsonAsync("api/companycontact", companyContact);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<CompanyContactDTO>();
            }

            return null;
        }

        public async Task DeleteCompanyContactAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"api/companycontact/{id}");
        }

        public async Task<CompanyContactDTO> GetCompanyContactAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<CompanyContactDTO>($"api/companycontact/{id}");
        }

        public async Task<int> GetCompanyContactCountAsync(Guid companyId)
        {
            return await _httpClient.GetFromJsonAsync<int>($"api/company/{companyId}/contacts/count");
        }

        public async Task<PaginatedResultDTO<CompanyContactDTO>> GetCompanyContactsAsync(Guid companyId, int page = 1, int recordsPerPage = 10)
        {
            return await _httpClient.GetFromJsonAsync<PaginatedResultDTO<CompanyContactDTO>>($"api/company/{companyId}/contacts?Page={page}&RecordsPerPage={recordsPerPage}");
        }

        public async Task UpdateCompanyContactAsync(CompanyContactDTO companyContact)
        {
            await _httpClient.PutAsJsonAsync($"api/companycontact/{companyContact.Id}", companyContact);
        }
    }
}
