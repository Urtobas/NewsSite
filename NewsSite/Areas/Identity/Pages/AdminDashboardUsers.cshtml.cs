using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewsSite.Data;
using NewsSite.Models;
using SQLitePCL;
using System.Security.Claims;

namespace NewsSite.Areas.Identity.Pages
{
    [Authorize(Policy = "GeneralPolicy")]
    public class AdminDashboardUsersModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public AdminDashboardUsersModel(ApplicationDbContext context)
        {
            _context = context;
            UserModel = _context.Users;
        }

        public List<UserViewModel> UsersViewModel { get; set; }
        public IEnumerable<ApplicationUser> UserModel { get; set; }

        public void OnGet()
        {
            UsersViewModel = new();
            foreach (var user in _context.Users)
            {

                var claimCollection = _context.UserClaims;
                var claim = claimCollection.FirstOrDefault(opt => opt.ClaimType == "Status" && opt.UserId == user.Id);
                string? status = "anonim";
                if (claim != null) status = claim.ClaimValue;

                UsersViewModel.Add(new UserViewModel()
                {
                    Id = user.Id,
                    Email = user.Email,
                    RealName = user.RealUserName,
                    Status = status
                });
            }
        }
    }



    public class UserViewModel
    {
        public string? Id { get; set; }
        public string? Email { get; set; }
        public string? RealName { get; set; }
        public string? Status { get; set; }
    }
}
