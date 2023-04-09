using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using mtuci_labs.Data;
using mtuci_labs.Models;

namespace mtuci_labs.Pages
{
    public class AdminModel : PageModel
    {
        private IWebHostEnvironment environment;
        private readonly MtuciLabsDbContext mtuciLabsDbContext;

        [BindProperty]
        public AddSubject AddSubjectRequest { get; set; }

        [BindProperty]
        public IFormFile Upload { get; set; }

        public AdminModel(MtuciLabsDbContext mtuciLabsDbContext, IWebHostEnvironment environment)
        {
            this.mtuciLabsDbContext = mtuciLabsDbContext;
            this.environment = environment;
        }
        public string IsAuth { get; set; }
        public void OnGet()
        {
            using (System.IO.StreamReader reader = System.IO.File.OpenText(@"Pages\IsAuth.txt"))
            {
                IsAuth = reader.ReadToEnd();
            }
        }

        public async Task OnPostAsync()
        {
            var file = Path.Combine(environment.ContentRootPath, "uploads",Upload.FileName);
           
            try
            {
                using(var filestream = new FileStream(file, FileMode.Create))
                {
                    await Upload.CopyToAsync(filestream);
                }
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
            }
            var subject = new Subject()
            {
                Name = AddSubjectRequest.Name,
                Path = Upload.FileName,
                Course = AddSubjectRequest.Course
            };
            mtuciLabsDbContext.Subjects.Add(subject);
            mtuciLabsDbContext.SaveChanges();
        }
    }
}
