using UssJuniorTest.Contracts;
using UssJuniorTest.Core.Models;

namespace UssJuniorTest
{
    public class PaginatedLogs
    {
        public PaginatedLogs(IEnumerable<DriveLogResponse> items, int count, int pageNumber, int logsPerPage)
        {
            PageInfo = new PageInfo
            {
                CurrentPage = pageNumber,
                LogsPerPage = logsPerPage,
                TotalPages = (int)Math.Ceiling(count / (double)logsPerPage),
                TotalLogs = count
            };

            Logs = items;
        }

        public PageInfo PageInfo { get; set; }

        public IEnumerable<DriveLogResponse> Logs { get; set; }

        public static PaginatedLogs ToPaginatedLogs(IEnumerable<DriveLogResponse> posts, int pageNumber, int logsPerPage)
        {
            var count = posts.Count();
            var chunk = posts.Skip((pageNumber - 1) * logsPerPage).Take(logsPerPage);
            return new PaginatedLogs(chunk, count, pageNumber, logsPerPage);
        }
    }
    public class PageInfo
    {
        public bool HasPreviousPage
        {
            get => CurrentPage > 1;
        }

        public bool HasNextPage
        {
            get => CurrentPage < TotalPages;
        }

        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int LogsPerPage { get; set; }
        public int TotalLogs { get; set; }
    }
}

