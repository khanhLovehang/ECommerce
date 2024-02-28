namespace Shared.DataTransferObjects.ReviewDto
{

    public record ReviewForUpdateDto( int ReviewId
                                     , Guid ProductId
                                     //, DateTime ReviewDate
                                     //, string ReviewBy
                                     //, Guid ReviewById
                                     , string? Detail
                                     , decimal? Rating
                                     , DateTime? UpdatedDate
                                     //, string? UpdatedBy
                                     //, Guid? UpdatedById
                                   );
}
