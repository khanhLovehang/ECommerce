namespace Shared.DataTransferObjects
{
    [Serializable]

    public record AttributeDto(int AttributeId
                                , int? Status
                                , string? AttributeName
                                        );
}
