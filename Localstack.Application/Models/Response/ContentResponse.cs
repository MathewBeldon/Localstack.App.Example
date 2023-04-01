using Localstack.Application.Models.Base;
using System.Text.Json.Serialization;

namespace Localstack.Application.Models.Response
{
    public record ContentResponse<T> : BaseResponse
    {
        [JsonConstructor]
        public ContentResponse(T data)
        {
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }

        [JsonInclude]
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public T Data { get; init; }
    }
}
