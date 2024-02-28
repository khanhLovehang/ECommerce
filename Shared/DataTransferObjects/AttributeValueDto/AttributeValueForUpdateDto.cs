namespace Shared.DataTransferObjects.AttributeValueDto
{

    public record AttributeValueForUpdateDto(int AttributeValueId
                                            , int AttributeId
                                            , Guid ProductId
                                            , string Value
                                            , DateTime? UpdatedDate
                                            , string? UpdatedBy
                                            , Guid? UpdatedById
                                            );
}
