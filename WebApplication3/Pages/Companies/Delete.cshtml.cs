using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication3.Pages.Companies
{
    public class DeleteModel : PageModel
    {
        private readonly ICompanyService _companyService;

        public DeleteModel(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [BindProperty]
        public Company Company { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _companyService.GetByIdAsync((int)id);

            if (company == null)
            {
                return NotFound();
            }
            else 
            {
                Company = company;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _companyService.GetByIdAsync((int)id);

            if (company != null)
            {
                await _companyService.DeleteAsync(company.Id);
            }

            return RedirectToPage("./Index");
        }
    }
}
