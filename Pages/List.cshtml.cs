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
        public string IsAuth { get; set; }
        public void OnGet()
        {
            using (System.IO.StreamReader reader = System.IO.File.OpenText(@"D:\VS\mtuci_project\Pages\IsAuth.txt"))
            {
                IsAuth = reader.ReadToEnd();
            }
            Subjects = mtuciLabsDbContext.Subjects.ToList();
        }
    }
}
