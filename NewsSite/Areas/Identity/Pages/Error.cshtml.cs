using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NewsSite.Areas.Identity.Pages
{
    public class ErrorModel : PageModel
    {
        public string? Message { get; set; }
        public void OnGet(string? message)
        {
            Message = message;
        }
    }
    public class MessageModel
    {
        public string? Message { get; set; }
    }

}
