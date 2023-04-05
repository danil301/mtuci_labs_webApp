using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using mtuci_labs.Models;

namespace mtuci_labs.Pages
{
    public class IndexModel : PageModel
    {
        public Subject sbj = new Subject();
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
            sbj.Name = "Физика";
            sbj.Path = "dcsad";
            sbj.Course = 1;

        }
    }
}