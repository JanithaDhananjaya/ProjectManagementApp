using Microsoft.AspNetCore.Mvc;
using ProjectManagementApp.Server.Data;
using ProjectManagementApp.Shared;
using System.Threading.Tasks;

namespace ProjectManagementApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class companyController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        //only on comapny exist
        Company company = new Company { name = "Axiata Digital Labs", email = "axiatadigitallabs.com", residenceNo = "12/A", streetName = "Union Place Road", city = "Colombo 11", district = "Colombo", contactNo = "0760898982" };

        public async Task<IActionResult> GetCompanyProfileDetails()
        {

            return Ok(company);
        }

        [HttpPost("api/company/create")]
        public async void CreateCompany([FromBody] Company company)
        {
            _context.Company.Add(company);
            await _context.SaveChangesAsync();
           
        }

    }
}
