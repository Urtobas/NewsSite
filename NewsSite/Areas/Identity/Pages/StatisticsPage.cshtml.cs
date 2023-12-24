using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewsSite.Data;
using NewsSite.Models;

namespace NewsSite.Areas.Identity.Pages
{
    public class StatisticsPageModel : PageModel
    {
        private readonly ApplicationDbContext _context; 
        public StatisticsPageModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public int CountArticles { get; set; }
        public int CountUsers { get; set; }
        public int CountCategories { get; set; }
        public IEnumerable<Article> Articles { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public List<string> CategoriesList { get; set; }
        public int[] EachCategoryCount { get; set; }
        public int[] EachCategoryCountRecent { get; set; }

        public void OnGet()
        {
            Categories = _context.Categories;
            CountArticles = _context.Articles.Count();
            CountUsers = _context.Users.Count();
            CountCategories = _context.Categories.Count();
            CategoriesList = new List<string>();
            Articles = _context.Articles;


            foreach (var elem in Categories)
            {
                CategoriesList.Add(elem.CategoryName);
            }

            EachCategoryCount = new int[CountCategories];
            for (int i = 0; i < CountCategories; i++)
            {
                foreach (var elem in Articles)
                {
                    if (elem.ArticleCategory == CategoriesList.ElementAt(i)) EachCategoryCount[i]++;
                }
            }
        }
    }
}
