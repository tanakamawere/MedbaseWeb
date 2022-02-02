namespace MedbaseWeb.Utils
{
    public class PagedList<T> : List<T>
    {
        public PagedList(List<T> query, QueryOptions options = null)
        {
            CurrentPage = options.CurrentPage;
            PageSize = options.PageSize;
            TotalPages = query.Count() / PageSize;
            TopicCode = options.Topic;
            Visibility = options.AnswerVisibility;
            NumberOfQuestions = query.Count();
            AddRange(query.Skip((CurrentPage - 1) * PageSize).Take(PageSize));
        }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TopicCode { get; set; }
        public int Visibility { get; set; }
        public int NumberOfQuestions { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
    }
    public class QueryOptions
    {
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int Topic { get; set; } = 1;
        public int AnswerVisibility { get; set; } = 0;
    }
}

