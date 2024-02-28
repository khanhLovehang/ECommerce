using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.ReviewDto
{

    public record ReviewForCreationDto
    {
        [Required(ErrorMessage = "ProductId is a required field.")]
        public Guid ProductId { get; init; }

        [Required(ErrorMessage = "ReviewDate is a required field.")]
        public DateTime ReviewDate { get; init; }

        [Required(ErrorMessage = "ReviewBy is a required field.")]
        [MaxLength(256, ErrorMessage = "Maximum length for the Value is 256 characters.")]
        public string? ReviewBy { get; init; }
        public Guid ReviewById { get; init; }
        public string? Detail { get; init; }
        public decimal? Rating { get; init; }
        public DateTime? CreatedDate { get; init; }
        public string? CreatedBy { get; init; }
        public Guid? CreatedById { get; init; }

                            
    }
}
