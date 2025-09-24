using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ESolutionsRazorPages.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> course { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
}