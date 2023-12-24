using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using NewsSite.Data;
using NewsSite.Models;
using System.Data;

namespace NewsSite.Pages
{
    public class SearchResultPageModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public SearchResultPageModel(ApplicationDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
            PaginationModel = new PaginationModel<Article>();
        }
        public IEnumerable<Article> SearchResultList { get; set; }
        public static PaginationModel<Article> PaginationModel { get; set; }
        public IMemoryCache _cache;
        public string Cache { get; set; } = "";
        public int CountSearchResult { get; set; } = 6;


        public void OnGet(int? pageNum, string? query)
        {
            CountSearchResult = _context.AppSettings.First().SearchPaginationCount;
            if(query != null && pageNum != null)
            {
                try
                {
                    SearchResultList = from e in _context.Articles
                                       where e.ArticleTitle.ToLower().Contains(query.ToLower())
                                       select e;
                    _cache.Set("cacheSearch", query, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(1)));
                    if(_cache != null)Cache = _cache.Get("cacheSearch").ToString();

                    PaginationModel.PageSize = CountSearchResult;
                    PaginationModel.Source = SearchResultList;
                    if (pageNum != null) PaginationModel.CurrentPage = pageNum;
                    else PaginationModel.CurrentPage = 1;
                    if (pageNum != null) PaginationModel.Result = PaginationModel.Source.Skip((int)(pageNum - 1) * PaginationModel.PageSize).Take(PaginationModel.PageSize);
                    else PaginationModel.Result = PaginationModel.Source.Skip(PaginationModel.PageSize).Take(PaginationModel.PageSize).Take(PaginationModel.PageSize);
                }
                catch
                {
                    GetDefaultPage();
                    PaginationModel.Result = new List<Article>();
                }
            }
            else
            {
                GetDefaultPage();
                PaginationModel.PageSize = 6;
                PaginationModel.Source = new List<Article>();
                if (pageNum != null) PaginationModel.CurrentPage = pageNum;
                else PaginationModel.CurrentPage = 1;
                if (pageNum != null) PaginationModel.Result = PaginationModel.Source.Skip((int)(pageNum - 1) * PaginationModel.PageSize).Take(PaginationModel.PageSize);
                else PaginationModel.Result = PaginationModel.Source.Skip(PaginationModel.PageSize).Take(PaginationModel.PageSize).Take(PaginationModel.PageSize);
            }
        }

        public IActionResult GetDefaultPage()
        {
            return RedirectToPage("Index");
        }
    }
}
