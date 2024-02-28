namespace Service.Contracts.Manager
{
    public interface IServiceManager
    {
        IUserService UserService { get; }
        IProductService ProductService { get; }
        IAttributeService AttributeService { get; }
        IAttributeValueService AttributeValueService { get; }
        ICategoryService CategoryService { get; }
        IReviewService ReviewService { get; }
    }
}
