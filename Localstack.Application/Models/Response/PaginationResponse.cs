namespace Localstack.Application.Models.Response
{
    public record PaginationResponse<T> : ContentResponse<IReadOnlyList<T>>
    {
        public PaginationResponse(IReadOnlyList<T> data) : base(data) { }

        public int Page { get; init; }
        public int PageSize { get; init; }
        public int RecordCount { get; init; }
        public int PageCount { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
    }
}
