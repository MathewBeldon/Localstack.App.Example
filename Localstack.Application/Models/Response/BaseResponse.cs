using System.Text.Json.Serialization;

namespace Localstack.Application.Models.Base
{
    public record BaseResponse
    {
        public BaseResponse() { }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Message { get; init; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Dictionary<string, string> ValidationErrors { get; init; }
    }
}
