using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ESolutionsRazorPages;

public class ValidateModelStatePageFilter : IPageFilter
{
    public void OnPageHandlerSelected(PageHandlerSelectedContext context)
    {
        // Not Used, required by interface
    }

    public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
    {
        if (context.HandlerInstance is PageModel page && 
            !page.ModelState.IsValid)
        {
            context.Result = page.Page(); 
        }
    }

    public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
    {
        // Not Used; required by interface
    }
}

