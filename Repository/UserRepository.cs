using Contracts;
using Entities;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {

        #region properties
        #endregion

        #region constructor
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
        #endregion

        #region methods
        #endregion

    }
}
