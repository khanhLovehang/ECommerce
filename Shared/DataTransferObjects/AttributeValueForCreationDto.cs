namespace Shared.DataTransferObjects
{

    public record AttributeValueForCreationDto(int? AttributeId
                                            , Guid? ProductId
                                             , string? Value
                                );
}
