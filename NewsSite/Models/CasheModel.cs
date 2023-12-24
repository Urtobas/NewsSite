using Microsoft.Extensions.Caching.Memory;
using NewsSite.Data;

namespace NewsSite.Models
{
    public class CasheModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cashe;
        public CasheModel(ApplicationDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cashe = cache;
        }


        public async Task<List<Article>> GetFoundItems(string query)
        {
            _cashe.TryGetValue(query, out List<Article>? articles);
            if(articles == null)
            {
                articles = (List<Article>)(from e in _context.Articles
                                           where e.ArticleTitle.ToLower().Contains(query.ToLower())
                                           select e);
                _cashe.Set(query, articles, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
            }
            return articles;
        }
    }
}
