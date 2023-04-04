namespace Localstack.Application.Models.Response
{
    public record PaginationResponse<T> : ContentResponse<IReadOnlyList<T>>
    {
        public PaginationResponse(IReadOnlyList<T> data, string? lastEvaluatedKey) : base(data) 
        {
            LastEvaluatedKey = lastEvaluatedKey;
        }
        public int PageSize { get; init; }
        public string? LastEvaluatedKey { get; init; }
    }
}
