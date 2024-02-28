using Shared.DataTransferObjects.AttributeValueDto;

namespace Shared.DataTransferObjects.ProductDto
{

    public record ProductForUpdateDto(string SKU
                                          , bool IsDeleted
                                          , int Status
                                          , int ProductType
                                          , string ProductName
                                          , decimal? Price
                                          , decimal? OldPrice
                                          , int CategoryId
                                          , int BrandId
                                          , string? ShortDescription
                                          , string? Description
                                          , decimal? DiscountPercent
                                          , int? QuantitySold
                                          , string Thumbnail
                                          , int? Gender
                                          , int? Age
                                          , DateTime? UpdatedDate
                                          , string UpdatedBy
                                          , Guid UpdatedById
                                          , int Quantity
                                          , int? StockStatus
                                          , DateTime NewFrom
                                          , DateTime NewTo
                                          , bool IsSale
                                          , bool IsNew
                                          , bool IsRecommend
                                          , bool IsShowOnMainPage
                                          , bool IsVisibility
                                          , IEnumerable<AttributeValueForCreationDto> AttributeValues
                            );
}
