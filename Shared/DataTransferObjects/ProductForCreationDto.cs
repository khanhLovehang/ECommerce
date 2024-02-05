using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{

    public record ProductForCreationDto(string SKU
                                          , bool IsDeleted
                                          , int Status
                                          , string ProductName
                                          , decimal Price
                                          , decimal OldPrice
                                          , int CategoryId
                                          , int BrandId
                                          , string ShortDescription
                                          , string Description
                                          , decimal DiscountPercent
                                          , int QuantitySold
                                          , string Thumbnail
                                          , int Gender
                                          , int Age
                                          , DateTime CreatedDate
                                          , string CreatedBy
                                          , Guid CreatedById
                                          , int Quantity
                                          , int StockStatus
                                          , DateTime NewFrom
                                          , DateTime NewTo
                                          , bool IsSale
                                          , bool IsNew
                                          , bool IsRecommend
                                          , bool IsShowOnMainPage
                                          , int ProductType
                            );
}
