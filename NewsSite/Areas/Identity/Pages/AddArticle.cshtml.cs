using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewsSite.Data;
using NewsSite.Models;
using AppLib;

namespace NewsSite.Areas.Identity.Pages
{
    [Authorize("GeneralPolicy")]
    public class AddArticleModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public Article Article { get; set; }
        public IEnumerable<Category> CategoryTitles { get; set; }
        public ApplicationUser? CurrentUser { get; set; }
        public IWebHostEnvironment _hostEnvironment;

        public AddArticleModel(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            CategoryTitles = _context.Categories;
        }

        public void OnGet()
        {
            Article = new();
            Article.PublicationDate = DateTime.Now;
            CurrentUser = _context.Users.FirstOrDefault(op => op.Email == User.Identity.Name);
            if (CurrentUser == null) CurrentUser = new();
        }

        public IActionResult OnPost(string author, string userEmail, string articleCategoty, string articleTitle,
            string articleContent, string keyWords, DateTime publicationDate, string pathToMainPhoto,
            bool isImportant, IFormFile fileUpload)
        {

            Article article = new();
            article = new()
            {
                Author = author,
                UserEmail = userEmail,
                ArticleCategory = articleCategoty,
                ArticleTitle = articleTitle,
                ArticleContent = articleContent,
                KeyWords = keyWords,
                PublicationDate = publicationDate,
                PathToMainPhoto = pathToMainPhoto,
                IsImportant = isImportant
            };

            if (fileUpload != null)
            {
                string path = "/article_img/" + AppMethods.CleanInput(article.ArticleTitle);
                string extension = fileUpload.FileName.Substring(fileUpload.FileName.Length - 4, 4);

                if (extension.ToLower().Contains("jpg"))
                {
                    using (FileStream fs = new FileStream(_hostEnvironment.WebRootPath + path + ".jpg", FileMode.Create))
                    {
                        fileUpload.CopyTo(fs);
                        article.PathToMainPhoto = path + ".jpg";
                    }
                }
                else if (extension.ToLower().Contains("jpeg"))
                {
                    using (FileStream fs = new FileStream(_hostEnvironment.WebRootPath + path + ".jpg", FileMode.Create))
                    {
                        fileUpload.CopyTo(fs);
                        article.PathToMainPhoto = path + ".jpg";
                    }
                }
                else if (extension.ToLower().Contains("webp"))
                {
                    using (FileStream fs = new FileStream(_hostEnvironment.WebRootPath + path + ".webp", FileMode.Create))
                    {
                        fileUpload.CopyTo(fs);
                        article.PathToMainPhoto = path + ".webp";
                    }
                }
                else if (extension.ToLower().Contains("png"))
                {
                    using (FileStream fs = new FileStream(_hostEnvironment.WebRootPath + path + ".png", FileMode.Create))
                    {
                        fileUpload.CopyTo(fs);
                        article.PathToMainPhoto = path + ".png";
                    }
                }
            }

            if (String.IsNullOrEmpty(article.KeyWords)) article.KeyWords = "новости";
            if (String.IsNullOrEmpty(article.PathToMainPhoto)) article.PathToMainPhoto = "/images/default_image.jpg";
            if (String.IsNullOrEmpty(article.ArticleTitle)) article.ArticleTitle = articleContent.Substring(0, 50) + "...";
            try
            {
                _context.Articles.Add(article);
                _context.SaveChanges();
                return RedirectToPage("AdminDashboard");
            }
            catch
            {
                return RedirectToPage("Error");
            }
        }
    }
}
