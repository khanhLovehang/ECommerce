namespace Shared.DataTransferObjects
{
    [Serializable]

    public record CategoryDto(int CategoryId
                            , string CategoryName
                            , DateTime? CreatedDate
                            , int ParentId
                        );
}
