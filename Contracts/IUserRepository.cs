using Entities.Models;

namespace Contracts
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers(bool trackChanges);
        User? GetUser(Guid userId, bool trackChanges);
    }
}
