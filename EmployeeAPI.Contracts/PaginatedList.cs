namespace EmployeeAPI.Contracts
{
    public class PaginatedList<T>(IEnumerable<T> items, int totalCount, int pageIndex, int pageSize)
    {
        public IEnumerable<T> Items { get; set; } = items;
        public int TotalCount { get; set; } = totalCount;
        public int TotalPages { get; set; } = (int)Math.Ceiling((double)totalCount / pageSize);
        public int PageIndex { get; set; } = pageIndex;
        public int PageSize { get; set; } = pageSize;
    }
}
