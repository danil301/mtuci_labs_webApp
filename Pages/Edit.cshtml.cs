using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using mtuci_labs.Data;
using mtuci_labs.Models;
using System;
using System.IO;

namespace mtuci_labs.Pages
{
    public class EditModel : PageModel
    {
        FileDelete FileDelete { get; set; }

        private readonly MtuciLabsDbContext mtuciLabsDbContext;
        [BindProperty]
        public Subject Subject { get; set; }
        [BindProperty]
        public IFormFile Upload { get; set; }
        public EditModel(MtuciLabsDbContext mtuciLabsDbContext)
        {
            this.mtuciLabsDbContext = mtuciLabsDbContext;
        }
        public void OnGet(Guid id)
        {
            Subject = mtuciLabsDbContext.Subjects.Find(id);
        }
        public IActionResult OnPostDelete()
        {
            var ExistingSubject = mtuciLabsDbContext.Subjects.Find(Subject.Id);

            if (ExistingSubject != null)
            {
                mtuciLabsDbContext.Subjects.Remove(ExistingSubject);
                mtuciLabsDbContext.SaveChanges();
            }
            FileDelete = new FileDelete();
            FileDelete.FileDeleteFromFoler(ExistingSubject.Path);
            return RedirectToPage("/List");
        }
    }
}
