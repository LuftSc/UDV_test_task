namespace UssJuniorTest
{
    public class PaginationParams
    {
        private const int _maxPageSize = 15;
        private int _page = 10;
        public int Page { get; set; } = 1;
        public int LogsPerPage
        {
            get { return _page; }
            set
            {
                if (value > _maxPageSize) _page = _maxPageSize;
                else _page = value;
            }
        }
    }
}
