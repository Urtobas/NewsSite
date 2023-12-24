using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace NewsSite.HtmlHelpers
{
    public static class PaginationHelper
    {
        public static HtmlString CreatePagination(this IHtmlHelper helper, int pageCount, int pageSize, int? currentPage, string pageName)
        {
            string result = @"<nav class='aria-label='Навигация по страницам'>";
            result += "<ul class='pagination'>";

            if (currentPage <= 1)
            {
                result += "<li class='page-item disabled'><a class='page-link'>ᐊᐊ</a></li>";
                result += $"<li class='page-item disabled'><a class='page-link'>ᐊ</a></li>";
            }
            else
            {
                result += $"<li class='page-item' title='В начало'><a class='page-link' href='/{pageName}/1'>ᐊᐊ</a></li>";
                result += $"<li class='page-item' title='Предыдущая'><a class='page-link' href='/{pageName}/{currentPage - 1}'>ᐊ</a></li>";
            }

            for (int i = 0; i < pageCount; i++)
            {
                if (i >= currentPage - 5 && i <= currentPage + 5)
                {
                    if (i+1 == currentPage) 
                    {
                        result += $"<li class='page-item active'><a class='page-link' href='/{pageName}/{i + 1}'>{i + 1}</a></li>";
                    }
                    else result += $"<li class='page-item'><a class='page-link' href='/{pageName}/{i + 1}'>{i + 1}</a></li>";
                }
            }

            if (currentPage >= pageCount)
            {
                result += "<li class='page-item disabled'><a class='page-link'>ᐅ</a></li>";
                result += "<li class='page-item disabled'><a class='page-link'>ᐅᐅ</a></li>";
            }
            else
            {
                result += $"<li class='page-item' title='Следующая'><a class='page-link' href='/{pageName}/{currentPage + 1}'>ᐅ</a></li>";
                result += $"<li class='page-item' title='К последней'><a class='page-link' class='page-link' href='/{pageName}/{pageCount}'>ᐅᐅ</a></li>";
            }
            result += "</ul>";
            result += "</nav>"; 
            return new HtmlString(result);
        }

        public static HtmlString CreateCategoryPagination(this IHtmlHelper helper, int pageCount, int pageSize, int? currentPage, string category)
        {
            string result = @"<nav class='aria-label='Навигация по страницам'>";
            result += "<ul class='pagination'>";
            if (currentPage <= 1)
            {
                result += "<li class='page-item disabled'><a class='page-link'>ᐊᐊ</a></li>";
                result += $"<li class='page-item disabled'><a class='page-link'>ᐊ</a></li>";
            }
            else
            {
                result += $"<li class='page-item' title='В начало'><a class='page-link' href='/SelectByCategory/{category}/1'  >ᐊᐊ</a></li>";
                result += $"<li class='page-item' title='Предыдущая'><a class='page-link' href='/SelectByCategory/{category}/{currentPage - 1}'>ᐊ</a></li>";
            }

            for (int i = 0; i < pageCount; i++)
            {
                if (i >= currentPage - 5 && i <= currentPage + 5)
                {
                    if(i+1 == currentPage)
                    {
                        result += $"<li class='page-item active'><a class='page-link'  href='/SelectByCategory/{category}/{i + 1}'>{i + 1}</a></li>";
                    }
                    else result += $"<li class='page-item'><a class='page-link'  href='/SelectByCategory/{category}/{i + 1}'>{i + 1}</a></li>";
                }
            }
            if (currentPage >= pageCount)
            {
                result += "<li class='page-item disabled'><a class='page-link'>ᐅ</a></li>";
                result += "<li class='page-item disabled'><a class='page-link'>ᐅᐅ</a></li>";
            }
            else
            {
                result += $"<li class='page-item' title='Следующая'><a class='page-link' href='/SelectByCategory/{category}/{currentPage + 1}'>ᐅ</a></li>";
                result += $"<li class='page-item' title='К последней'><a class='page-link' class='page-link' href='/SelectByCategory/{category}/{pageCount}'>ᐅᐅ</a></li>";
            }
            result += "</ul>";
            result += "</nav>";
            return new HtmlString(result);
        }

        public static HtmlString CreateSearchPagination(this IHtmlHelper helper, int pageCount, int pageSize, 
             int? currentPage, string pageName, string query)
        {
            string result = @"<nav class='aria-label='Навигация по страницам'>";
            result += "<ul class='pagination'>";

            if (currentPage <= 1)
            {
                result += "<li class='page-item disabled'><a class='page-link'>ᐊᐊ</a></li>";
                result += $"<li class='page-item disabled'><a class='page-link'>ᐊ</a></li>";
            }
            else
            {
                result += $"<li class='page-item' title='В начало'><a class='page-link' href='/{pageName}/1?query={query}'>ᐊᐊ</a></li>";
                result += $"<li class='page-item' title='Предыдущая'><a class='page-link' href='/{pageName}/{currentPage - 1}?query={query}'>ᐊ</a></li>";
            }

            for (int i = 0; i < pageCount; i++)
            {
                if (i >= currentPage - 5 && i <= currentPage + 5)
                {
                    if (i + 1 == currentPage)
                    {
                        result += $"<li class='page-item active'><a class='page-link' href='/{pageName}/{i + 1}?query={query}'>{i + 1}</a></li>";
                    }
                    else result += $"<li class='page-item'><a class='page-link' href='/{pageName}/{i + 1}?query={query}'>{i + 1}</a></li>";
                }
            }

            if (currentPage >= pageCount)
            {
                result += "<li class='page-item disabled'><a class='page-link'>ᐅ</a></li>";
                result += "<li class='page-item disabled'><a class='page-link'>ᐅᐅ</a></li>";
            }
            else
            {
                result += $"<li class='page-item' title='Следующая'><a class='page-link' href='/{pageName}/{currentPage + 1}?query={query}'>ᐅ</a></li>";
                result += $"<li class='page-item' title='К последней'><a class='page-link' class='page-link' href='/{pageName}/{pageCount}?query={query}'>ᐅᐅ</a></li>";
            }
            result += "</ul>";
            result += "</nav>";
            return new HtmlString(result);
        }
    }
}
