namespace Shared.DataTransferObjects.CategoryDto
{
    [Serializable]

    public record CategoryDto(int CategoryId
                            ,bool? IsDeleted
                            ,int? Status
                            ,string? CategoryName
                            ,int? ParentId
                        );
}
