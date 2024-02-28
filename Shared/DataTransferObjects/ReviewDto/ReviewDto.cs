namespace Shared.DataTransferObjects.ReviewDto
{
    [Serializable]

    public record ReviewDto(int ReviewId
                            ,Guid ProductId
                            ,DateTime ReviewDate
                            ,string ReviewBy 
                            ,Guid ReviewById
                            ,string? Detail
                            ,decimal? Rating
                            ,DateTime? CreatedDate
                            ,string? CreatedBy
                            ,Guid? CreatedById
                            ,DateTime? UpdatedDate
                            ,string? UpdatedBy
                            ,Guid? UpdatedById
                            ,DateTime? DeletedDate
                            ,string? DeletedBy
                            ,Guid? DeletedById
                                );
}
