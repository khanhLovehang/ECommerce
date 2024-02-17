namespace Shared.DataTransferObjects
{
    [Serializable]

    public record AttributeValueDto(int AttributeValueId
                                 , int? AttributeId
                                 , Guid? ProductId
                                 , string? Value
                                );
}
