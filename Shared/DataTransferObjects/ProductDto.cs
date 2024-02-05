namespace Shared.DataTransferObjects
{
    [Serializable]

    public record ProductDto(Guid ProductId
                            , string? Sku
                            , string ProductName
                            , decimal? Price
                            , decimal? OldPrice
                            , int? CategoryId
                            , int? BrandId
                            , string? ShortDescription
                            , string? Description
                            , int? DiscountPercent
                            , int QuantitySold
                            , string? Thumbnail
                            , int? Gender
                            , int? Age
                            , int? StockStatus
                            , DateTime? NewFrom
                            , DateTime? NewTo
                            , bool? IsSale
                            , bool? IsNew
                            , bool? IsRecommend
                            , bool? IsShowOnMainPage
                            , int? ProductType
                        );
}
