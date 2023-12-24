using AppLib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewsSite.Data;
using NewsSite.Models;
using System.Data;
using System.Security.Claims;

namespace NewsSite.Areas.Identity.Pages
{
    [Authorize(Policy = "GeneralPolicy")]
    public class EditArticleModel : PageModel
    {
        public Article? Article { get; set; }
        public IEnumerable<Category> CategoryTitles { get; set; }

        public ApplicationUser? CurrentUser { get; set; }

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public EditArticleModel(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            CategoryTitles = _context.Categories;
        }

        public void OnGet(int id)
        {
            Article = _context.Articles.FirstOrDefault(op => op.Id == id);
        }

        public IActionResult OnPost(
            string author, string articleCategory, string articleTitle, string userEmail,
            string articleContent, string keyWords, DateTime publicationDate, string pathToMainPhoto, bool isImportant,
            int id, IFormFile fileUpload)
        {
            Claim? userClaim = HttpContext.User.Claims.FirstOrDefault(opt => opt.Type == "Status" && opt.Value == "admin");
            Article = _context.Articles.FirstOrDefault(op => op.Id == id);
            string? currentEmail = HttpContext.User.Identity.Name;
            ApplicationUser? currentUser = _context.Users.FirstOrDefault(opt => opt.Email == currentEmail);

            if (Article != null && currentUser != null)
            {
                Article.Author = author;
                Article.UserEmail = userEmail;
                Article.ArticleCategory = articleCategory;
                Article.ArticleTitle = articleTitle;
                Article.ArticleContent = articleContent;
                Article.KeyWords = keyWords;
                Article.PublicationDate = publicationDate;
                Article.PathToMainPhoto = pathToMainPhoto;
                Article.IsImportant = isImportant;
                if ((Article != null && HttpContext.User.HasClaim("Status", "admin")) || (Article != null && currentUser.Email == Article.UserEmail))
                {
                    if (fileUpload != null)
                    {
                        string path = "/article_img/" + AppMethods.CleanInput(Article.ArticleTitle);
                        string extension = fileUpload.FileName.Substring(fileUpload.FileName.Length - 4, 4);

                        if (extension.ToLower().Contains("jpg"))
                        {
                            using (FileStream fs = new FileStream(_hostEnvironment.WebRootPath + path + ".jpg", FileMode.Create))
                            {
                                fileUpload.CopyTo(fs);
                                Article.PathToMainPhoto = path + ".jpg";
                            }
                        }
                        else if (extension.ToLower().Contains("jpeg"))
                        {
                            using (FileStream fs = new FileStream(_hostEnvironment.WebRootPath + path + ".jpg", FileMode.Create))
                            {
                                fileUpload.CopyTo(fs);
                                Article.PathToMainPhoto = path + ".jpg";
                            }
                        }
                        else if (extension.ToLower().Contains("webp"))
                        {
                            using (FileStream fs = new FileStream(_hostEnvironment.WebRootPath + path + ".webp", FileMode.Create))
                            {
                                fileUpload.CopyTo(fs);
                                Article.PathToMainPhoto = path + ".webp";
                            }
                        }
                        else if (extension.ToLower().Contains("png"))
                        {
                            using (FileStream fs = new FileStream(_hostEnvironment.WebRootPath + path + ".png", FileMode.Create))
                            {
                                fileUpload.CopyTo(fs);
                                Article.PathToMainPhoto = path + ".png";
                            }
                        }
                    }

                    if (String.IsNullOrEmpty(Article.KeyWords)) Article.KeyWords = "новости";
                    if (String.IsNullOrEmpty(Article.PathToMainPhoto)) Article.PathToMainPhoto = "/images/default_image.jpg";
                    if (String.IsNullOrEmpty(Article.ArticleTitle)) Article.ArticleTitle = Article.ArticleContent.Substring(0, 50) + "...";
                    try
                    {
                        _context.Articles.Update(Article);
                        _context.SaveChanges();
                        return RedirectToPage("AdminDashboard");
                    }
                    catch
                    {
                        return RedirectToPage("Error");
                    }
                }
                else return RedirectToPage("Error", new MessageModel { Message = "У вас недостаточно прав доступа для редактирования этой статьи" });
            }
            else return RedirectToPage("Error", new MessageModel { Message = "Непредвиденная ошибка при редактировании статьи"});
        }



        public IActionResult OnGetDelete(int id)
        {
            Article = _context.Articles.FirstOrDefault(op => op.Id == id);
            string? currentEmail = HttpContext.User.Identity.Name;
            ApplicationUser? currentUser = _context.Users.FirstOrDefault(opt => opt.Email == currentEmail);
            
            if ((Article != null && HttpContext.User.HasClaim("Status", "admin")) || (Article != null && currentUser.Email == Article.UserEmail))
            {
                _context.Articles.Remove(Article);
                int result = _context.SaveChanges();
                if (result > 0)
                {
                    FileInfo fileInfo = new(_hostEnvironment.WebRootPath + Article.PathToMainPhoto);
                    if (fileInfo.Exists && Article.PathToMainPhoto != "/images/default_image.jpg") fileInfo.Delete();
                }
                return RedirectToPage("AdminDashboard");
            }
            else return RedirectToPage("Error", new MessageModel { Message = "У вас недостаточно прав доступа для удаления этой статьи"});
        }
    }
}
