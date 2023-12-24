using System.ComponentModel.DataAnnotations;

namespace NewsSite.Models
{
    public class ColorsSettings
    {
        public int Id { get; set; }

        
        [Display(Name = "Количество новостей на Главной в разделе Последние новости")]
        public int IndexPaginationCount { get; set; }

        [Display(Name = "Количество новостей в разделе Популярные статьи")]
        public int IndexCountPopularArticles { get; set; }

        [Display(Name = "Количество новостей в разделе Новости за день")]
        public int IndexCountLastDayArticles { get; set; }

        [Display(Name = "Количество новостей в разделе Прочтите также")]
        public int IndexCountReadMoreArticles { get; set; }

        [Display(Name = "Количество новостей в разделе Важные новости")]
        public int IndexCountImportantArticles { get; set; }

        [Display(Name = "Количество новостей в разделе Технологии, досуг")]
        public int IndexCountSocialArticles { get; set; }

        [Display(Name = "Количество новостей в разделе Спортивные новости")]
        public int IndexCountSportArticles { get; set; }

        [Display(Name = "Количество новостей в разделе Финансовые новости")]
        public int IndexCountFinanceArticles { get; set; }

        [Display(Name = "Количество новостей в разделе Происшествия, криминал")]
        public int IndexCountCriminalArticles { get; set; }

        [Display(Name = "Количество новостей в разделе Война на Украине")]
        public int IndexCountUkraineWarArticles { get; set; }

        [Display(Name = "Количество новостей на странице Выбор по категории")]
        public int SelectedCategoryPaginationCount { get; set; }

        [Display(Name = "Количество новостей на странице поиска")]
        public int SearchPaginationCount { get; set; }
    }
}
