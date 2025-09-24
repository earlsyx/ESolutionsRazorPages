using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ESolutionsRazorPages.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ESolutionsRazorPages.Pages.Authors
{
    public class CreateModel : PageModel
    {
        private readonly ESolutionsRazorPages.Data.ApplicationDbContext _context;

        public CreateModel(ESolutionsRazorPages.Data.ApplicationDbContext context)
        {
            _context = context;
            AllCourses = _context.course
               .Select(c => new SelectListItem
               {
                   Value = c.Id.ToString(),
                   Text = c.Name
               }).ToList();
        }

        public IActionResult OnGet()
        {
           
            return Page();
        }

        [BindProperty]
        public CreateAuthorRequest InputModel { get; set; } = default!;
        public List<SelectListItem> AllCourses { get; set; }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var newAuthor = new Author
            {
                Name = InputModel.Name
            };

            _context.Authors.Add(newAuthor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public class CreateAuthorRequest
        {
            [Required]
            public string Name { get; set; } = default!;
            [EmailAddress]
            [Display(Name = "Email Address")]
            public string EmailAddress { get; set; } = default!;
            [Phone]
            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; } = default!;
            public bool IsActive { get; set; } = false;

            [Display(Name = "Favorite Color")]
            public string FavoriteColor { get; set; } = default!;
            [Display(Name = "Courses Authored")]
            public List<int> CoursesAuthored { get; set; } = new();
            [Display(Name = "Date of Birth")]
            public DateTime? DateOfBirth { get; set; } = default!;
            [Display(Name = "Employment Type")]
            public EmploymentType EmploymentType { get; set; } = default!;
        }
    }
}

public enum EmploymentType
{
    FullTime,
    PartTime,
    Contractor
}