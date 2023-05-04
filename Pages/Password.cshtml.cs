using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace mtuci_labs.Pages
{
    public class PasswordModel : PageModel
    {
        [BindProperty]
        public string Entered_Password { get; set; }
        public void OnGet()
        {

        }
        public RedirectToPageResult OnPost()
        {
            string password = Entered_Password;
            string pass = string.Empty;
            string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            Console.WriteLine(_filePath);
            using (System.IO.StreamReader reader = System.IO.File.OpenText($"{_filePath}/pass.txt"))
            {
                pass = reader.ReadToEnd();
            }
            if (Entered_Password == pass)
            {
                string str = string.Empty;
                using (System.IO.StreamReader reader = System.IO.File.OpenText(@"Pages\IsAuth.txt"))
                {
                    str = reader.ReadToEnd();
                }
                str = str.Replace("false", "true");

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Pages\IsAuth.txt"))
                {
                    file.Write(str);
                }
                return RedirectToPage("/Admin_Panel");
            }
            else { return RedirectToPage("/Password"); };
        }
        
    }
}
