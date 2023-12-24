using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewsSite.Data;
using NewsSite.Models;

namespace NewsSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;

        public static IEnumerable<Article>? AllArticles { get; set; }
        public static IEnumerable<Article>? PopularArticles { get; set; }
        public static IEnumerable<Article>? ImportantArticles { get; set; }
        public static IEnumerable<Article>? SocialArticles { get; set; }
        public static IEnumerable<Article>? SportArticles { get; set; }
        public static IEnumerable<Article>? ReadMoreArticles { get; set; }
        public static IEnumerable<Article>? LastDayArticles { get; set; }
        public static IEnumerable<Article>? FinanceArticles { get; set; }
        public static IEnumerable<Article>? CriminalArticles { get; set; }
        public static IEnumerable<Article>? UkraineWarArticles { get; set; }

        public static IEnumerable<Category>? Categories { get; set; }

        public static PaginationModel<Article> PaginationModel { get; set; }
        public static ColorsSettings? Settings { get; set; }

        private int IndexPaginationCount { get; set; }
        private int CountPopularArticles { get; set; }
        private int CountImportantArticles { get; set; }
        private int CountSocialArticles { get; set; }
        private int CountSportArticles { get; set; }
        private int CountFinanceArticles { get; set; }
        private int CountReadMoreArticles { get; set; }
        private int CountLastDayArticles { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
            PaginationModel = new();
            AllArticles = _context.Articles.ToList();
            Categories = _context.Categories.ToList();
            Settings = _context.AppSettings.FirstOrDefault();
            if(Settings != null)
            {
                IndexPaginationCount = Settings.IndexPaginationCount;
                CountPopularArticles  = Settings.IndexCountPopularArticles;
                CountImportantArticles = Settings.IndexCountImportantArticles;
                CountSocialArticles = Settings.IndexCountSocialArticles;
                CountSportArticles = Settings.IndexCountSportArticles;
                CountFinanceArticles = Settings.IndexCountFinanceArticles;
                CountReadMoreArticles = Settings.IndexCountReadMoreArticles;
                CountLastDayArticles = Settings.IndexCountLastDayArticles;
            }
        }

        public void OnGet(int? pageNum=1)
        {
           
            PaginationModel.PageSize = IndexPaginationCount;
            if(pageNum != null) PaginationModel.CurrentPage = pageNum; 
            else PaginationModel.CurrentPage = 1;
            PaginationModel.Source = from e in AllArticles.ToList()
                                     orderby e.PublicationDate descending
                                     select e;
            if(pageNum != null) PaginationModel.Result = PaginationModel.Source.Skip((int)(pageNum-1) * PaginationModel.PageSize).Take(PaginationModel.PageSize);
            else PaginationModel.Result = PaginationModel.Source.Skip(PaginationModel.PageSize).Take(PaginationModel.PageSize);

            PopularArticles = (from e in AllArticles.ToList()
                               orderby e.VievsCount descending
                              select e).Take(CountPopularArticles);

            ImportantArticles = (from e in AllArticles.ToList()
                                 where e.IsImportant == true
                              orderby e.PublicationDate descending
                              select e).Take(CountImportantArticles);

            SocialArticles = (from e in AllArticles.ToList()
                              where e.ArticleCategory == "Технологии, досуг"
                              orderby e.PublicationDate descending
                             select e).Take(CountSocialArticles);

            SportArticles = (from e in AllArticles.ToList()
                             where e.ArticleCategory == "Спорт"
                             orderby e.PublicationDate descending
                             select e).Take(CountSportArticles);

            FinanceArticles = (from e in AllArticles.ToList()
                               where e.ArticleCategory == "Финансы"
                             orderby e.PublicationDate descending
                             select e).Take(CountFinanceArticles);

            Random rnd = new();
            ReadMoreArticles = AllArticles.OrderBy(op => rnd.Next()).Take(CountReadMoreArticles);

            LastDayArticles = (from e in AllArticles
                               where e.PublicationDate > (DateTime.Now).AddHours(-24)
                               select e).OrderBy(op => rnd.Next()).Take(CountLastDayArticles);
        }
    }
}