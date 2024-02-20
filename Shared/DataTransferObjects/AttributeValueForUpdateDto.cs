namespace Shared.DataTransferObjects
{

    public record AttributeValueForUpdateDto(int? AttributeId
                                            //, Guid? ProductId
                                             , string? Value
                                );
}
