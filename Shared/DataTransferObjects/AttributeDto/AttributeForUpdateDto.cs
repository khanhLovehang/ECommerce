namespace Shared.DataTransferObjects.AttributeDto
{

    public record AttributeForUpdateDto(int AttributeId
                                        , bool? IsDeleted
                                        , int? Status
                                        , string? AttributeName
                                        , DateTime? UpdatedDate
                                        , string? UpdatedBy
                                        , Guid? UpdatedById
                                );
}
