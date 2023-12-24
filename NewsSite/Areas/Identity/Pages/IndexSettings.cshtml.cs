using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewsSite.Data;
using NewsSite.Models;

namespace NewsSite.Areas.Identity.Pages
{
    [Authorize(Policy = "GeneralPolicy")]
    public class IndexSettingsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public static ColorsSettings Settings { get; set; }

        public IndexSettingsModel(ApplicationDbContext context)
        {
            _context = context;
            if (_context.AppSettings != null) Settings = _context.AppSettings.FirstOrDefault();
            else
            {
                Settings = new()
                {
                    IndexCountCriminalArticles = 2,
                    IndexCountFinanceArticles = 2,
                    IndexCountImportantArticles = 6,
                    IndexCountLastDayArticles = 4,
                    IndexCountPopularArticles = 10,
                    IndexCountReadMoreArticles = 6,
                    IndexCountSocialArticles = 3,
                    IndexCountSportArticles = 2,
                    IndexCountUkraineWarArticles = 1
                };
            }
        }
        public void OnGet()
        {
            
        }

        public IActionResult OnPost(ColorsSettings settings)
        {
            Settings = _context.AppSettings.FirstOrDefault();

            if(Settings != null && HttpContext.User.HasClaim("Status","admin"))
            {
                Settings.IndexPaginationCount = settings.IndexPaginationCount;
                Settings.IndexCountImportantArticles = settings.IndexCountImportantArticles;
                Settings.IndexCountCriminalArticles = settings.IndexCountCriminalArticles;
                Settings.IndexCountFinanceArticles = settings.IndexCountFinanceArticles;
                Settings.IndexCountLastDayArticles = settings.IndexCountLastDayArticles;
                Settings.IndexCountPopularArticles = settings.IndexCountPopularArticles;
                Settings.IndexCountReadMoreArticles = settings.IndexCountReadMoreArticles;
                Settings.IndexCountSocialArticles = settings.IndexCountSocialArticles;
                Settings.IndexCountSportArticles = settings.IndexCountSportArticles;
                Settings.IndexCountUkraineWarArticles = settings.IndexCountUkraineWarArticles;
                Settings.SelectedCategoryPaginationCount = settings.SelectedCategoryPaginationCount;
                Settings.SearchPaginationCount = settings.SearchPaginationCount;
            }


            if (ModelState.IsValid && Settings != null && HttpContext.User.HasClaim("Status","admin"))
            {
                _context.AppSettings.Update(Settings);
                _context.SaveChanges();
                return RedirectToPage();
            }
            else return RedirectToPage("Error", new MessageModel() { Message = "У вас недостаточно прав доступа для редактирования вида главной страницы сайта" });
        }
    }
}
