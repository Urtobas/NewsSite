using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using NewsSite.Data;
using NewsSite.Models;

namespace NewsSite.Areas.Identity.Pages
{
    [Authorize(Policy = "GeneralPolicy")]
    public class AdminDashboardModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public static PaginationModel<Article> PaginationModel { get; set; }
        public int CountArticlesTableRow { get; set; } = 30;
        public string SelectedCategory { get; set; }
        public static IEnumerable<Article> SelectedByCategories { get; set; }
        private IMemoryCache _cache;
        public string cach = "";

        public AdminDashboardModel(ApplicationDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }
       
        public void OnGet(string category = "nocategory", int? pageNum = 1)
        {
            if (category == "nocategory")
            {
                SelectedByCategories = from e in _context.Articles
                                       orderby e.PublicationDate descending
                                       select e;
                _cache.Set("categoryCache", category);
                cach = _cache.Get("categoryCache").ToString();
            }
            else
            {
                SelectedByCategories = from e in _context.Articles
                                       where e.ArticleCategory == category || e.Author == category
                                       orderby e.PublicationDate descending
                                       select e;
                _cache.Set("categoryCache", category);
                cach = _cache.Get("categoryCache").ToString();
            }

            PaginationModel = new();
            PaginationModel.PageSize = CountArticlesTableRow;
            if (pageNum != null) PaginationModel.CurrentPage = pageNum;
            else PaginationModel.CurrentPage = 1;
            PaginationModel.Source = from e in SelectedByCategories.ToList() 
                                     orderby e.PublicationDate descending
                                     select e;
            if (pageNum != null) PaginationModel.Result = PaginationModel.Source.Skip((int)(pageNum - 1) * PaginationModel.PageSize).Take(PaginationModel.PageSize);
            else PaginationModel.Result = PaginationModel.Source.Skip(PaginationModel.PageSize).Take(PaginationModel.PageSize);  
        }
    }
}
