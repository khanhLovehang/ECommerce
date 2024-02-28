using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.AttributeValueDto
{

    public record AttributeValueForCreationDto
    {
        [Required(ErrorMessage = "AttributeId is a required field.")]
        public int? AttributeId { get; init; }

        [Required(ErrorMessage = "ProductId is a required field.")]
        public Guid? ProductId { get; init; }

        [Required(ErrorMessage = "Value is a required field.")]
        [MaxLength(500, ErrorMessage = "Maximum length for the Value is 500 characters.")]
        public string? Value { get; init; }

        public string? CreatedDate { get; init; }

        public string? CreatedBy { get; init; }

        public string? CreatedById { get; init; }
    }
}
