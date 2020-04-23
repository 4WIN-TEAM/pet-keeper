using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetKeeper.Common
{
    public class Response<T> : Result<T>, IResponse<T>
    {
        public string Message { get; set; }
    }

    public class NoValue
    {

    }
}
