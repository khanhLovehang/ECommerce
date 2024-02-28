namespace Shared.DataTransferObjects.AttributeDto
{
    [Serializable]

    public record AttributeDto(int AttributeId
                                , int? Status
                                , string? AttributeName
                                        );
}
