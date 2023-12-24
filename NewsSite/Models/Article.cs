using System.ComponentModel.DataAnnotations;

namespace NewsSite.Models
{
    public class Article
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Необходимо ввести имя автора"), Display(Name = "Автор статьи")]
        public string Author { get; set; }

        [Required, Display(Name = "Почта автора")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Необходимо выбрать категорию"), Display(Name = "Категория")]
        public string ArticleCategory { get; set; }

        [Required(ErrorMessage = "Необходимо добавить название статьи"), Display(Name = "Название статьи")]
        public string ArticleTitle { get; set; }

        [Required, Display(Name = "Текст статьи"), MinLength(100, ErrorMessage = "Длина статьи должна быть не менее 100 символов")]
        public string ArticleContent { get; set; }

        [Required, Display(Name = "Ключевые слова"), MinLength(4, ErrorMessage = "Введите хотя бы одно ключевое слово длиной не менее 4 символов")]
        public string? KeyWords { get; set; }

        [Required, Display(Name = "Дата публикации")]
        public DateTime PublicationDate { get; set; }

        [Display(Name = "Добавить ссылку на заглавное изображение для статьи")]
        public string PathToMainPhoto { get; set; }

        public int? VievsCount { get; set; } = 0;

        [Display(Name = "Присвоить статье статус 'Важное'")]
        public bool IsImportant { get; set; }

        public virtual List<Tag>? Tags { get; set; }
        public virtual List<ApplicationUser>? UserEmails { get; set; }
    }
}
