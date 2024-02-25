using Application.Interfaces;
using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Pages.Offices
{
    public class DeleteModel : PageModel
    {
        private readonly IOfficeService _officeService;

        public DeleteModel(IOfficeService officeService)
        {
            _officeService = officeService;
        }

        [BindProperty]
        public Office Office { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var office = await _officeService.GetByIdAsync((int)id);

            if (office == null)
            {
                return NotFound();
            }
            else
            {
                Office = office;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var office = await _officeService.GetByIdAsync((int)id);

            if (office != null)
            {
                await _officeService.DeleteAsync(office.Id);
            }

            return RedirectToPage("/Offices/Index");
        }
    }
}
