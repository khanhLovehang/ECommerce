namespace Shared.DataTransferObjects.AttributeDto
{

    public record AttributeForCreationDto(bool? IsDeleted
                                        , int? Status
                                        , string? AttributeName
                                        , DateTime? CreatedDate
                                        , string? CreatedBy
                                        , Guid? CreatedById
                                        );
}
