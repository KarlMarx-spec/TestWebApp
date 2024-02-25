using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication3.Views.Home
{
    public class ExportModel : PageModel
    {
        private readonly IXMLGeneratorService _XMLGeneratorService;
        private readonly ICompanyService _companyService;

        [BindProperty]
        public string Directory { get; set; }

        public ExportModel(IXMLGeneratorService XMLGeneratorService, ICompanyService companyService)
        {
            _XMLGeneratorService = XMLGeneratorService;
            _companyService = companyService;
        }

        public async Task OnGetAsync()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!string.IsNullOrEmpty(Directory))
            {
                var companies = await _companyService.GetCompaniesWithDepartmentsAsync();

                var myWriter = new StreamWriter($"{Directory}\\Companies.xml");

                _XMLGeneratorService.GetXMLFromObject(myWriter, companies);

                myWriter.Close();
            }

            return Page();
        }
    }
}
