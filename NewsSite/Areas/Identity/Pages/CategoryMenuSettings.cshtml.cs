using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewsSite.Data;
using NewsSite.Models;

namespace NewsSite.Areas.Identity.Pages
{
    [Authorize(Policy = "GeneralPolicy")]
    public class CategoryMenuSettingsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public CategoryMenuSettingsModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Category> CatagoryList { get; set; }

        public void OnGet()
        {
            CatagoryList = _context.Categories.ToList<Category>();
        }

        public IActionResult OnPost(string category)
        {
            if(!String.IsNullOrEmpty(category) && HttpContext.User.HasClaim("Status","admin"))
            {
                _context.Categories.Add(new Category() { CategoryName = category });
                int result = _context.SaveChanges();
                if (result > 0) return Page();
                else return RedirectToPage("Error", new MessageModel() { Message = "¬озникла непредвиденна€ ошибка при добавлении категории"});
            }
            else if(String.IsNullOrEmpty(category)) return RedirectToPage("Error", new MessageModel() { Message = "ƒобавьте название категории" });
            else return RedirectToPage("Error", new MessageModel() { Message = "” вас недостаточно прав дл€ добавлени€ или удалени€ категорий" });
        }

        public IActionResult OnGetDeleteCategory(int id)
        {
            Category? category = _context.Categories.FirstOrDefault(op => op.Id == id);
            if (category != null && HttpContext.User.HasClaim("Status", "admin"))
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
                CatagoryList = _context.Categories.ToList<Category>();
                return Page();
            }
            else return RedirectToPage("Error", new MessageModel() { Message = "” вас недостаточно прав дл€ добавлени€ или удалени€ категорий" });    
        }
    }
}
