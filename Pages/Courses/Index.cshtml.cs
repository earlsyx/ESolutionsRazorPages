using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ESolutionsRazorPages.Data;

namespace ESolutionsRazorPages.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly ESolutionsRazorPages.Data.ApplicationDbContext _context;

        public IndexModel(ESolutionsRazorPages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Course> Course { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Course = await _context.course.ToListAsync();
        }
    }
}
