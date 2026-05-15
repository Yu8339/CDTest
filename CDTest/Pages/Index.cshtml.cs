using CDTestLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CDTest.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int NumA { get; set; }

        [BindProperty(SupportsGet = true)]
        public int NumB { get; set; }

        public int Result { get; set; }

        public void OnGet()
        {
            var calculator = new Calculator();
            Result = calculator.Add(NumA, NumB);
        }
    }
}
