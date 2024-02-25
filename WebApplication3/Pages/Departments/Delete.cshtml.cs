using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication3.Pages.Departments
{
    public class DeleteModel : PageModel
    {
        private readonly IDepartmentService _departmentService;

        public DeleteModel(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [BindProperty]
        public Department Department { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _departmentService.GetByIdAsync((int)id);

            if (department == null)
            {
                return NotFound();
            }
            else 
            {
                Department = department;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var department = await _departmentService.GetByIdAsync((int)id);

            if (department != null)
            {
                await _departmentService.DeleteAsync((int)id);
            }

            return RedirectToPage("/Departments/Index");
        }
    }
}
