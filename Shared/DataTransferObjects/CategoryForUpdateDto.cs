using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{

     public record CategoryForUpdateDto(string CategoryName
                                  , DateTime? UpdatedDate 
                                  , string? UpdatedBy 
                                  , Guid? UpdatedById 
                                  , int? ParentId
                            );
}
