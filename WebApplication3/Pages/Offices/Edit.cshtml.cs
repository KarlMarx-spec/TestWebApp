using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Pages.Offices
{
    public class EditModel : PageModel
    {
        private readonly IOfficeService _officeService;

        public EditModel(IOfficeService officeService)
        {
            _officeService = officeService;
        }

        [BindProperty]
        public Office Office { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var office =  await _officeService.GetByIdAsync((int)id);
            if (office == null)
            {
                return NotFound();
            }

            Office = office;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _officeService.ChangeAsync((int)id!, Office);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return RedirectToPage("/Offices/Index");
        }
    }
}
