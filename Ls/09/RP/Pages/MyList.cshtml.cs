using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RP.Pages
{
    public class MyListModel : PageModel
    {
        public IEnumerable<string>? TheList { get; set; }
        public void OnGet()
        {
            ViewData["Title"] = "This is My List Razor Page";
            TheList = [
                "One", "Two", "Three",
            ];
        }
    }
}
