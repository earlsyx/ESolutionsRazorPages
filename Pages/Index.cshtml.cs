using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ESolutionsRazorPages.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        private readonly ILogger<IndexModel> _logger;
        private readonly LinkGenerator _linkGenerator;

        public IndexModel(ILogger<IndexModel> logger,
            LinkGenerator linkGenerator)
        {
            _logger = logger;
            _linkGenerator = linkGenerator;
        }

        public IActionResult OnGet()
        {
            string pageName = "Privacy";

            string? privacyLink = Url.Page(pageName);
            string? privacyLink2 = _linkGenerator.GetPathByPage(HttpContext, pageName);
            string? privacyLink3 = _linkGenerator.GetUriByPage(HttpContext, pageName);

            //return RedirectToPage(pageName);
            //return NotFound();
            return Page();
        }

        public void OnGetSpecial()
        {

        }
    }
}
