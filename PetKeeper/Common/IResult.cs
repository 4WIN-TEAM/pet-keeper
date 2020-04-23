using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetKeeper.Common
{
    public interface IResult<T>
    {
        bool Succedded { get; set; }
        T Value { get; set; }
    }
}
