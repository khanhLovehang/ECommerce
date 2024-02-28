namespace Shared.DataTransferObjects.CategoryDto
{

    public record CategoryForCreationDto(string CategoryName
                                  , DateTime? CreatedDate
                                  , string? CreatedBy
                                  , Guid? CreatedById
                                  , int? ParentId
                           );
}
