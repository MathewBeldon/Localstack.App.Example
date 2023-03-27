using System.ComponentModel.DataAnnotations;

namespace Localstack.Domain.Entities
{
    public sealed class Movie : BaseEntity
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
    }
}
