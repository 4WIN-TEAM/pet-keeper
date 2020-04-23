using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetKeeper.Common
{
    public class Result<T> : IResult<T>
    {
        public bool Succedded { get; set; }
        public T Value { get; set; }
    }
}
