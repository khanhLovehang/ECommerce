using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions.Base
{
    public abstract class BadRequestException : Exception
    {
        #region properties
        #endregion

        #region constructor
        protected BadRequestException(string message)
            : base(message)
        {
        }
        #endregion

        #region methods
        #endregion
    }
}
