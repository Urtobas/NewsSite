using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewsSite.Data;
using NewsSite.Models;

namespace NewsSite.Pages
{
    public class SelectByCategoryModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public SelectByCategoryModel(ApplicationDbContext context)
        {
            _context = context;
            ColorsSettings? set = _context.AppSettings.FirstOrDefault();
            if (set != null) SelectedCategoryPaginationCount = set.SelectedCategoryPaginationCount;
            else SelectedCategoryPaginationCount = 6;
        }

        public static IEnumerable<Article> SelectedArticles { get; set; }
        public static PaginationModel<Article> PaginationModel { get; set; }
        private int SelectedCategoryPaginationCount { get; set; }

        public void OnGet(string category, int? pageNum = 1)
        {
            SelectedArticles = from e in _context.Articles.ToList()
                               where e.ArticleCategory == category
                               orderby e.PublicationDate descending
                               select e;
            PaginationModel = new();
            PaginationModel.PageSize = SelectedCategoryPaginationCount;
            PaginationModel.CurrentPage = pageNum;
            PaginationModel.Source = SelectedArticles;

            if (pageNum != null) PaginationModel.Result = PaginationModel.Source.Skip((int)(pageNum - 1) * PaginationModel.PageSize).Take(PaginationModel.PageSize);
            else PaginationModel.Result = PaginationModel.Source.Skip(PaginationModel.PageSize).Take(PaginationModel.PageSize);
        }
    }
}
