using FinanceAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinanceAPI.Controllers
{
    [Route("/api/company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;


        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchCompanies([FromQuery] string query)
        {
            var companies = await _companyService.SearchCompanies(query);
            if (companies == null || !companies.Any()) return NotFound("No companies found matching the query.");
            //if (companies == null || !companies.Any()) return NotFound("No companies found matching the query.");
            return Ok();
        }


        [HttpGet("{ticker}")]
        public async Task<IActionResult> GetCompanyDetails(string ticker)
        {
            var company = await _companyService.GetCompanyDetails(ticker);
            if (company == null) return NotFound("Company not found.");
            return Ok(company);
        }
    }
}