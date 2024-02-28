namespace Shared.DataTransferObjects.CategoryDto
{

    public record CategoryForUpdateDto(string CategoryName
                                 , DateTime? UpdatedDate
                                 , string? UpdatedBy
                                 , Guid? UpdatedById
                                 , int? ParentId
                           );
}
