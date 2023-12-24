using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewsSite.Areas.Identity.Pages;
using NewsSite.Models;

namespace NewsSite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public new DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ColorsSettings> AppSettings { get; set; }
        public DbSet<SettingsColor> SettingsColors { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}