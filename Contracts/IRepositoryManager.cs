using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Contracts
{
    //A repository manager class,
    //which will create instances of repository user classes for us and then
    //register them inside the dependency injection container.After that, we
    //can inject it inside our services with constructor injection (supported by
    //ASP.NET Core). With the repository manager class in place, we may call
    //any repository user class we need.
    public interface IRepositoryManager
    {
        IUserRepository User { get; }
        IProductRepository Product { get; }
        IAttributeRepository Attribute { get; }
        IAttributeValueRepository AttributeValue { get; }

        Task SaveAsync();
    }
}
