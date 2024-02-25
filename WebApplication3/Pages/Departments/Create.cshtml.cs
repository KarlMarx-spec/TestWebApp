using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication3.Pages.Departments
{
    public class CreateModel : PageModel
    {
        private readonly IDepartmentService _departmentService;

        public CreateModel(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Department Department { get; set; }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Department == null)
            {
                return Page();
            }

            await _departmentService.AddAsync(new Department
            {
                Name = Department.Name,
                CompanyId = Department.CompanyId
            });

            return RedirectToPage("/Departments/Index");
        }
    }
}
