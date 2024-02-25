using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication3.Pages.Offices
{
    public class IndexModel : PageModel
    {
        private readonly IOfficeService _officeService;

        public IndexModel(IOfficeService officeService)
        {
            _officeService = officeService;
        }

        public IList<Office> Offices { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Offices = await _officeService.GetAllAsync();
        }
    }
}
