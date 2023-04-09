using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using mtuci_labs.Data;
using mtuci_labs.Models;

namespace mtuci_labs.Pages
{
    public class MathDbModel : PageModel
    {
        public List<FileModel> Files { get; set; }
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment Environment;

        private readonly MtuciLabsDbContext mtuciLabsDbContext;

        public List<Subject> Subjects { get; set; }

        public MathDbModel(MtuciLabsDbContext mtuciLabsDbContext, Microsoft.AspNetCore.Hosting.IHostingEnvironment enviroment)
        {
            this.Environment = enviroment;
            this.mtuciLabsDbContext = mtuciLabsDbContext;
        }
        public void OnGet()
        {
            Subjects = mtuciLabsDbContext.Subjects.ToList();
            string[] filePaths = Directory.GetFiles(Path.Combine(this.Environment.WebRootPath, "../uploads/"));

            this.Files = new List<FileModel>();
            foreach (string filepath in filePaths)
            {
                this.Files.Add(new FileModel { FileName = Path.GetFileName(filepath) });
            }
        }
        public FileResult OnGetDownloadFile(string fileName)
        {
            //Build the File Path.
            string path = Path.Combine(this.Environment.WebRootPath, "../uploads/") + fileName;

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
        }
    }
}
