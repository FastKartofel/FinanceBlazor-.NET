using Microsoft.AspNetCore.Mvc;
using FinanceAPI.Services.Interfaces;
using FinanceAPI.DTO;

namespace FinanceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
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
