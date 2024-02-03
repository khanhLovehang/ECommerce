using Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IProductService> _productService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger)
        {
            _userService = new Lazy<IUserService>(() => new UserService(repositoryManager, logger));
            _productService = new Lazy<IProductService>(() => new ProductService(repositoryManager, logger));
        }

        public IUserService UserService => _userService.Value;
        public IProductService ProductService => _productService.Value;
    }
}
