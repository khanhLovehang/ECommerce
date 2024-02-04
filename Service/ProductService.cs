using AutoMapper;
using Contracts;
using Entities;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class ProductService : IProductService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ProductService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }


        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            try
            {
                var products = _repository.Product.GetAllProducts(trackChanges).ToList();
                //var usersDto = users.Select(u => new UserDto(u.UserId, u.UserName ?? "", u.Email ?? "")).ToList();
                //var usersDto = _mapper.Map<IEnumerable<Product>>(products); // User auto mapper
                return products;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllProducts)} service method {ex}");
                throw;
            }
        }

    }
}
