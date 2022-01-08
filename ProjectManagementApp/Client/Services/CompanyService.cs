using ProjectManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ProjectManagementApp.Client.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly HttpClient _httpClient;

        public CompanyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Company> GetCompanyProfileDetails()
        {
           return await _httpClient.GetFromJsonAsync<Company>("api/company");
        }
    }
}
