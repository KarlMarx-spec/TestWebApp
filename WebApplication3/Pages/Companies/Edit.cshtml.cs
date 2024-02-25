﻿using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Pages.Companies
{
    public class EditModel : PageModel
    {
        private readonly ICompanyService _companyService;

        public EditModel(ICompanyService companyService)
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
            Company = company;
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
                await _companyService.ChangeAsync((int)id!, Company);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return RedirectToPage("/Companies/Index");
        }
    }
}
