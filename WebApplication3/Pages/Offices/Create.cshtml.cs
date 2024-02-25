using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication3.Pages.Offices
{
    public class CreateModel : PageModel
    {
        private readonly IOfficeService _officeService;

        public CreateModel(IOfficeService officeService)
        {
            _officeService = officeService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Office Office { get; set; }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Office == null)
            {
                return Page();
            }

            await _officeService.AddAsync(new Office
            {
                Name = Office.Name,
                DepartmentId = Office.DepartmentId
            });

            return RedirectToPage("/Offices/Index");
        }
    }
}
