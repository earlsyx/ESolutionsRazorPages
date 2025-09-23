using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ESolutionsRazorPages.Data;
using System.ComponentModel.DataAnnotations;

namespace ESolutionsRazorPages.Pages.Courses
{
    public class CreateModel : PageModel
    {
        private readonly ESolutionsRazorPages.Data.ApplicationDbContext _context;

        public CreateModel(ESolutionsRazorPages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BindingModel BindingModel { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var course = new Course()
            {
                Name = BindingModel.Name
            };

            _context.course.Add(course);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }

    public class BindingModel
    {
        [Required]
        public string Name { get; set; } = default!;

    }
}

