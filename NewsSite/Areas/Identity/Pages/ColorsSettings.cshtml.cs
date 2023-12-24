using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewsSite.Data;
using NewsSite.Models;
using System.IO;
using SQLitePCL;
using Microsoft.AspNetCore.Authorization;

namespace NewsSite.Areas.Identity.Pages
{
    [Authorize(Policy = "GeneralPolicy")]
    public class ColorsSettingsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;
        
        public ColorsSettingsModel(ApplicationDbContext context, IWebHostEnvironment webHostEnviroment)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
            SiteRootPath = _webHostEnviroment.WebRootPath;
        }
        public static SettingsColor? SettingsColor { get; set; }
        public static string? SiteRootPath { get; set; }

        public void OnGet()
        {
            SettingsColor = _context.SettingsColors.FirstOrDefault();
        }



            public IActionResult OnPost(SettingsColor settingsColor)
        {
            SettingsColor = _context.SettingsColors.FirstOrDefault();
            if (SettingsColor != null && HttpContext.User.HasClaim("Status","admin"))
            {
                SettingsColor.HeaderColor = settingsColor.HeaderColor;
                SettingsColor.HeaderHoverColor = settingsColor.HeaderHoverColor;
                SettingsColor.ContextTextColor = settingsColor.ContextTextColor;
                SettingsColor.BlockquoteTextColor = settingsColor.BlockquoteTextColor;
                SettingsColor.BlockquoteBorderColor = settingsColor.BlockquoteBorderColor;
                SettingsColor.LinkColor = settingsColor.LinkColor;
                SettingsColor.LinkHoverColor = settingsColor.LinkHoverColor;

                SettingsColor.PaginationActiveColor = settingsColor.PaginationActiveColor;
                SettingsColor.PaginationHoverColor = settingsColor.PaginationHoverColor;
                SettingsColor.PaginationDisabledColor = settingsColor.PaginationDisabledColor;
                SettingsColor.PaginationBorderColor = settingsColor.PaginationBorderColor;
                SettingsColor.PaginationBorderHoverColor = settingsColor.PaginationBorderHoverColor;
                SettingsColor.PaginationFontColor = settingsColor.PaginationFontColor;
                SettingsColor.PaginationFontHoverColor = settingsColor.PaginationFontHoverColor;

                SettingsColor.MenuBackgroundColor = settingsColor.MenuBackgroundColor;
                SettingsColor.MenuBackgroundHoverColor = settingsColor.MenuBackgroundHoverColor;
                SettingsColor.MenuFontColor = settingsColor.MenuFontColor;
                SettingsColor.MenuFontHoverColor = settingsColor.MenuFontHoverColor;
                SettingsColor.MenuBorderColor = settingsColor.MenuBorderColor;
                SettingsColor.MenuBorderHoverColor = settingsColor.MenuBorderHoverColor;

                SettingsColor.AdminFontColor = settingsColor.AdminFontColor;
                SettingsColor.AdminBackgroundColor = settingsColor.AdminBackgroundColor;
                SettingsColor.AdminHeaderColor = settingsColor.AdminHeaderColor;
                SettingsColor.AdminMenuBackgroundColor = settingsColor.AdminMenuBackgroundColor;
                SettingsColor.AdminMenuFontColor = settingsColor.AdminMenuFontColor;
                SettingsColor.AdminMenuFontHoverColor = settingsColor.AdminMenuFontHoverColor;


                _context.SettingsColors.Update(SettingsColor);
                _context.SaveChanges();
               
                string path = SiteRootPath + "/css/colors.css";
                string contentCSSfile = ":root {\n";
                contentCSSfile += $"--main-header-color:  {SettingsColor.HeaderColor};\n";
                contentCSSfile += $"--main-header-color-hover:  {SettingsColor.HeaderHoverColor};\n";
                contentCSSfile += $"--content-text-color:  {SettingsColor.ContextTextColor};\n";
                contentCSSfile += $"--blockquote-text-color:  {SettingsColor.BlockquoteTextColor};\n";
                contentCSSfile += $"--blockquote-border-color:  {SettingsColor.BlockquoteBorderColor};\n";
                contentCSSfile += $"--link-color:  {SettingsColor.LinkColor};\n";
                contentCSSfile += $"--link-hover-color:  {SettingsColor.LinkHoverColor};\n";

                contentCSSfile += $"--pagination-active-color:  {SettingsColor.PaginationActiveColor};\n";
                contentCSSfile += $"--pagination-hover-color:  {SettingsColor.PaginationHoverColor};\n";
                contentCSSfile += $"--pagination-disabled-color:  {SettingsColor.PaginationDisabledColor};\n";
                contentCSSfile += $"--pagination-border-color:  {SettingsColor.PaginationBorderColor};\n";
                contentCSSfile += $"--pagination-border-hover-color:  {SettingsColor.PaginationBorderHoverColor};\n";
                contentCSSfile += $"--pagination-font-color:  {SettingsColor.PaginationFontColor};\n";
                contentCSSfile += $"--pagination-font-hover-color:  {SettingsColor.PaginationFontHoverColor};\n";

                contentCSSfile += $"--menu-background-color:  {SettingsColor.MenuBackgroundColor};\n";
                contentCSSfile += $"--menu-font-color:  {SettingsColor.MenuFontColor};\n";
                contentCSSfile += $"--menu-background-hover-color:  {SettingsColor.MenuBackgroundColor};\n";
                contentCSSfile += $"--menu-font-hover-color:  {SettingsColor.MenuFontHoverColor};\n";
                contentCSSfile += $"--menu-border-color:  {SettingsColor.MenuBorderColor};\n";
                contentCSSfile += $"--menu-border-hover-color:  {SettingsColor.MenuBorderHoverColor};\n";

                contentCSSfile += $"--admin-font-color:  {SettingsColor.AdminFontColor};\n";
                contentCSSfile += $"--admin-background-color:  {SettingsColor.AdminBackgroundColor};\n";
                contentCSSfile += $"--admin-header-color:  {SettingsColor.AdminHeaderColor};\n";
                contentCSSfile += $"--admin-menu-background-color:  {SettingsColor.AdminMenuBackgroundColor};\n";
                contentCSSfile += $"--admin-menu-font-color:  {SettingsColor.AdminMenuFontColor};\n";
                contentCSSfile += $"--admin-menu-font-hover-color:  {SettingsColor.AdminMenuFontHoverColor};\n";
                contentCSSfile += "}";
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                    System.IO.File.AppendAllText(path,contentCSSfile);
                }
                return RedirectToPage();
            }
            else
            {
                SettingsColor = new()
                {
                    HeaderColor = settingsColor.HeaderColor,
                    ContextTextColor = settingsColor.ContextTextColor
                };
                
                _context.SettingsColors.Add(SettingsColor);
                int result = _context.SaveChanges();
                if(result > 0)
                {
                   
                }
                return RedirectToPage("Error", new MessageModel()
                {
                    Message = "” нас недостаточно прав дл€ установки цветовых настроек сайта. " +
                "¬аш уровень доступа позвол€ет только ознакомительный просмотр возможностей административной панели."
                });
            }
        }
    }
}
