using System.ComponentModel.DataAnnotations;

namespace NewsSite.Models
{
    public class SettingsColor
    {
        public int Id { get; set; }

        // общие цвета
        [Display(Name = "Цвет заголовков")]
        public string HeaderColor { get; set; } = "#000000";

        [Display(Name = "Цвет заголовков при наведении курсора")]
        public string HeaderHoverColor { get; set; } = "#000000";

        [Display(Name = "Цвет основного текста статей")]
        public string ContextTextColor { get; set; } = "#000000";

        [Display(Name = "Цвет текста цитат")]
        public string BlockquoteTextColor { get; set; } = "#000000";

        [Display(Name = "Цвет бордера цитат")]
        public string BlockquoteBorderColor { get; set; } = "#000000";

        [Display(Name = "Цвет ссылок")]
        public string LinkColor { get; set; } = "#000000";

        [Display(Name = "Цвет ссылок при наведении курсора")]
        public string LinkHoverColor { get; set; } = "#000000";

        // Пагинация
        [Display(Name = "Цвет активной кнопки пагинации")]
        public string PaginationActiveColor { get; set; } = "#FFF";

        [Display(Name = "Цвет кнопок пагинации при наведении курсора")]
        public string PaginationHoverColor { get; set; } = "#000000";

        [Display(Name = "Цвет шрифта кнопки пагинации")]
        public string PaginationFontColor { get; set; } = "DarkGray";

        [Display(Name = "Цвет шрифта пагинации при наведении курсора")]
        public string PaginationFontHoverColor { get; set; } = "#000000";

        [Display(Name = "Цвет недоступных кнопок пагинации")]
        public string PaginationDisabledColor { get; set; } = "LightGray";

        [Display(Name = "Цвет бордера кнопок пагинации")]
        public string PaginationBorderColor { get; set; } = "SkyBlue";

        [Display(Name = "Цвет бордера кнопок пагинации при наведении курсора")]
        public string PaginationBorderHoverColor { get; set; } = "LightBlue";

        // Меню категорий
        [Display(Name = "Цвет фона")]
        public string MenuBackgroundColor { get; set; } = "#000000";

        [Display(Name = "Цвет шрифта")]
        public string MenuFontColor { get; set; } = "#000000";

        [Display(Name = "Фон при наведении курсора")]
        public string MenuBackgroundHoverColor { get; set; } = "#000000";

        [Display(Name = "Цвет шрифта при наведении курсора")]
        public string MenuFontHoverColor { get; set; } = "#000000";

        [Display(Name = "Цвет бордера")]
        public string MenuBorderColor { get; set; } = "#000000";

        [Display(Name = "Цвет бордера при наведении курсора")]
        public string MenuBorderHoverColor { get; set; } = "#000000";

        // Админ панель

        [Display(Name = "Цвет шрифта")]
        public string AdminFontColor { get; set; } = "#000000";

        [Display(Name = "Цвет заголовков")]
        public string AdminHeaderColor { get; set; } = "#000000";

        [Display(Name = "Цвет фона панели")]
        public string AdminBackgroundColor { get; set; } = "#000000";

        [Display(Name = "Цвет фона меню")]
        public string AdminMenuBackgroundColor { get; set; } = "#000000";

        [Display(Name = "Цвет шрифта меню")]
        public string AdminMenuFontColor { get; set; } = "#000000";

        [Display(Name = "Цвет шрифта меню при наведении курсора")]
        public string AdminMenuFontHoverColor { get; set; } = "#000000";
    }
}
