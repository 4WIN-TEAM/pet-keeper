using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetKeeper.Common
{
    public interface IResponse<T> : IResult<T>
    {
        string Message { get; set; }
    }
}
