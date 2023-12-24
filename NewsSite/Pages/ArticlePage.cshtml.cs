using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewsSite.Data;
using NewsSite.Models;
using System.Net;

namespace NewsSite.Pages
{
    public class ArticlePageModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public Article? CurrentArticle {get; set;}
        public ArticlePageModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet(int id)
        {
            CurrentArticle = _context.Articles.FirstOrDefault(op => op.Id == id);
            if (CurrentArticle == null) CurrentArticle = new();
            else
            {
                CurrentArticle.VievsCount += 1;
                _context.Articles.Update(CurrentArticle);
                _context.SaveChanges();
            }
        }

        public static HtmlString ConvertContent(string? input)
        {
            string result = "";
            if (!String.IsNullOrEmpty(input))
            {
                result = input.Replace("\n", "<br/>").Replace("\t", "");
                return new HtmlString(result);
            }
            else return new HtmlString("<div class='header-2'><strong>Статья не найдена</strong></div>");
        }
    }
}
