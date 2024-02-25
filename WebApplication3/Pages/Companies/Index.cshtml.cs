using Application.Interfaces;
using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Pages.Companies
{
    public class IndexModel : PageModel
    {
        private readonly ICompanyService _companyService;

        public IndexModel(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public IList<Company> Companies { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Companies = await _companyService.GetAllAsync();
        }
    }
}
