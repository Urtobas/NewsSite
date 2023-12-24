using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewsSite.Data;
using NewsSite.Models;

namespace NewsSite.Areas.Identity.Pages
{
    [Authorize(Policy = "GeneralPolicy")]
    public class LogoModel : PageModel
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ApplicationDbContext _context;
        public LogoModel(IWebHostEnvironment hostEnvironment, ApplicationDbContext context)
        {
            _hostEnvironment = hostEnvironment;
            _context = context;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost(IFormFile logo)
        {
            if (HttpContext.User.HasClaim("Status", "admin"))
            {
                using (FileStream fs = new FileStream(_hostEnvironment.WebRootPath + "/images/" + "logo.png", FileMode.Create))
                {
                    logo.CopyTo(fs);
                }
                return Page();
            }
            else return RedirectToPage("Error", new MessageModel() {Message = "У нас недостаточно прав для замены логотипа сайта. " +
                "Ваш уровень доступа позволяет только ознакомительный просмотр возможностей административной панели" });
        }
    }
}
