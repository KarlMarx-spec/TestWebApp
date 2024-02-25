using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication3.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly IDepartmentService _departmentService;

        public IndexModel(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public IList<Department> Departments { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Departments = await _departmentService.GetAllAsync();
        }
    }
}
