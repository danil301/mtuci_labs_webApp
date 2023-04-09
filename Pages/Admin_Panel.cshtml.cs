using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace mtuci_labs.Pages
{
    public class Admin_PanelModel : PageModel
    {
        public string IsAuth { get; set; }
        public void OnGet()
        {
            using (System.IO.StreamReader reader = System.IO.File.OpenText(@"Pages\IsAuth.txt"))
            {
                IsAuth = reader.ReadToEnd();
            }
        }
    }
}
