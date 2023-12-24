namespace NewsSite.Models
{
    public class PaginationModel<T>
    {

        public IEnumerable<T>? Source { get; set; }
        public IEnumerable<T>? Result { get; set; }
        public int SourceCount { get { return Source.Count(); } }
        public int PageSize { get; set; }
        public int PageCount
        {
            get
            {
                return (int)Math.Ceiling(SourceCount / (double)PageSize);
            }
        }
        public int? CurrentPage { get; set; }

        public bool HasPreviousPage
        {
            get
            {
                return (CurrentPage > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (CurrentPage < PageCount);
            }
        }
    }
}
