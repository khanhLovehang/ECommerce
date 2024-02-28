using Contracts;
using Entities.Models;
using Repository.Base;
using Repository.Context;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {

        #region properties
        #endregion

        #region constructor
        public UserRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        #endregion

        #region methods
        public IEnumerable<User> GetAllUsers(bool trackChanges)
        {
            return FindAll(trackChanges).OrderBy(i => i.UserName).ToList();
        }

        public User? GetUser(Guid userId, bool trackChanges)
        {
            return FindByCondition(i => i.UserId.Equals(userId), trackChanges).SingleOrDefault();
        }
        #endregion

    }
}
