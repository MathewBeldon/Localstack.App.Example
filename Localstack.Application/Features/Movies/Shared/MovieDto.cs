namespace Localstack.Application.Features.Movies.Commands.CreateMovie
{
    public sealed record MovieDto(
        string Id,
        string Title,
        int Year,
        string Director);
}
