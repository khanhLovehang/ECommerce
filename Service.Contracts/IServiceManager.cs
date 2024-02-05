namespace Service.Contracts
{
    public interface IServiceManager
    {
        IUserService UserService { get; }
        IProductService ProductService { get; }
    }
}
