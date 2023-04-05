using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using mtuci_labs.Data;
using mtuci_labs.Models;

namespace mtuci_labs.Pages
{
    public class ListModel : PageModel
    {
        private readonly MtuciLabsDbContext mtuciLabsDbContext;

        public List<Subject> Subjects { get; set; }

        public ListModel(MtuciLabsDbContext mtuciLabsDbContext)
        {
            this.mtuciLabsDbContext = mtuciLabsDbContext;
        }
        public void OnGet()
        {
            Subjects = mtuciLabsDbContext.Subjects.ToList();
        }
    }
}
