using ProjectManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementApp.Client.Services
{
    public interface ICompanyService
    {
        Task<Company> GetCompanyProfileDetails();
    }
}
