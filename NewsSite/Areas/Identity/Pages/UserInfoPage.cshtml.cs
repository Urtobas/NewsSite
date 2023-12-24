using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewsSite.Data;
using NewsSite.Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace NewsSite.Areas.Identity.Pages
{
    [Authorize(Policy = "GeneralPolicy")]
    public class UserInfoPageModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserInfoPageModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public ApplicationUser? SelectedUser { get; set; }
        [Display(Name = "—татус пользовател€")]
        public IdentityUserClaim<string>? UserClaim { get; set; }

        [Display(Name = "—татус пользовател€")]
        public string? UserClaimValue { get; set; }

        public IActionResult OnGet(string? id)
        {
            if (id != null)
            {
                SelectedUser = _context.Users.FirstOrDefault(opt => opt.Id == id);
                var claimsCollection = _context.UserClaims;
                if (SelectedUser != null) UserClaim = claimsCollection.FirstOrDefault(opt => opt.ClaimType == "Status" && opt.UserId == id);
                if (UserClaim != null) UserClaimValue = UserClaim.ClaimValue;
                return Page();
            }
            else return RedirectToPage("Error", new MessageModel()
            {
                Message = "” нас недостаточно прав дл€ редактировани€ уровн€ доступа пользовател€. ƒанные права предоставлены только администратору сайта. " +
                "¬аш уровень доступа позвол€ет только ознакомительный просмотр возможностей административной панели."
            });
        }

        public async Task<IActionResult> OnPost(string? id, string? userClaimValue)
        {
            SelectedUser = _context.Users.FirstOrDefault(opt => opt.Id == id);
            if (SelectedUser != null && userClaimValue != null && HttpContext.User.HasClaim("Status","admin"))
            {
                var claimCollection = await _userManager.GetClaimsAsync(SelectedUser);
                var oldClaim = claimCollection.FirstOrDefault(opt => opt.Type == "Status");
                var newClaim = new Claim("Status", userClaimValue);
                await _userManager.ReplaceClaimAsync(SelectedUser, oldClaim, newClaim);
                return RedirectToPage("/AdminDashboardUsers");
            }
            else return RedirectToPage("Error", new MessageModel()
            {
                Message = "” нас недостаточно прав дл€ редактировани€ уровн€ доступа пользовател€. ƒанные права предоставлены только администратору сайта. " +
                "¬аш уровень доступа позвол€ет только ознакомительный просмотр возможностей административной панели."
            });
        }
    }
}
