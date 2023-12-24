using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewsSite.Data;
using NewsSite.Models;

namespace NewsSite.Pages
{
    public class TestPageModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public static IEnumerable<Article> Articles { get; set; }
        public static Article? Article { get; set; }

        public TestPageModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet(int id)
        {
            Article = _context.Articles.FirstOrDefault(op => op.Id == id);
        }
    }
}
